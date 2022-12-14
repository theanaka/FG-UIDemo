using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipEquipment : MonoBehaviour
{

    [Header("Game State")]
    [SerializeField] bool isTravelling;

    [Header("Text Colors")]
    [SerializeField] Color availableColor;
    [SerializeField] Color unavailableColor;

    [Header("Current Equipment")]
    [SerializeField] int currentAmmo;
    [SerializeField] int currentRockets;
    [SerializeField] float currentFuel;
    [SerializeField] float currentGold;

    [Header("Start Equipment")]
    [SerializeField] int startAmmo;
    [SerializeField] int startRockets;
    [SerializeField] int startFuel;
    [SerializeField] int startGold;
    [SerializeField] int maxFuel;

    [Header("Prices")]
    [SerializeField] int ammoPrice;
    [SerializeField] int rocketPrice;
    [SerializeField] int fuelPrice;
    [SerializeField] int shipPrice;
    [SerializeField] int colonyPrice;

    [Header("Equipment Purcase Units")]
    [SerializeField] int ammoUnit;
    [SerializeField] int rocketUnit;
    [SerializeField] int fuelUnit;

    [Header("HUD Elements")]
    [SerializeField] TMP_Text ammoText;
    [SerializeField] TMP_Text rocketsText;
    [SerializeField] Image fuelFilling;
    [SerializeField] TMP_Text goldText;

    [Header("Shop Button Texts")]
    [SerializeField] TMP_Text ammoShopText;
    [SerializeField] TMP_Text rocketsShopText;
    [SerializeField] TMP_Text fuelShopText;
    [SerializeField] TMP_Text shipShopText;
    [SerializeField] TMP_Text colonyShopText;

    [Header("Shop Buttons")]
    [SerializeField] Button ammoShopButton;
    [SerializeField] Button rocketsShopButton;
    [SerializeField] Button fuelShopButton;
    [SerializeField] Button shipShopButton;
    [SerializeField] Button colonyShopButton;

    [Header("Refill/Depletion Rates")]
    [SerializeField] float fuelRate;
    [SerializeField] float goldRate;    

    [Header("Scripts")]
    [SerializeField] UIManager uiManager;
    [SerializeField] AudioManager audioManager;

    void Start()
    {
        SetStartEquipment();
    }

    void Update()
    {
        //In this little demo, money is generated when the ship is not travelling
        //When the ship is travelling, fuel is consumed
        if (isTravelling && currentFuel > 0)
        {
            currentFuel -= Time.deltaTime * fuelRate;
            DisplayCurrentFuel();
        }
        else
        {
            currentGold += Time.deltaTime * goldRate;
            DisplayCurrentGold();
            ShowShopAvailability();
        }
    }

    //Resetting equipment to start values
    void SetStartEquipment()
    {
        currentAmmo = startAmmo;
        currentRockets = startRockets;
        currentFuel = startFuel;
        currentGold = startGold;

        DisplayEquipmentInHUD();
    }

    //Updating the whole HUD
    void DisplayEquipmentInHUD()
    {
        DisplayCurrentAmmo();
        DisplayCurrentRockets();
        DisplayCurrentFuel();
        DisplayCurrentGold();
    }

    //Displaying the current amount of Ammo in the HUD
    void DisplayCurrentAmmo()
    {
        ammoText.text = currentAmmo.ToString();
    }

    //Displaying the current amount of Rockets in the HUD
    void DisplayCurrentRockets()
    {
        rocketsText.text = currentRockets.ToString();
    }

    //Displaying the current amount of Fuel in the HUD
    void DisplayCurrentFuel()
    {
        fuelFilling.fillAmount = (float) currentFuel / (float) maxFuel;
    }

    //Displaying the current amount of Gold in the HUD
    void DisplayCurrentGold()
    {
        goldText.text = ((int) currentGold).ToString();
    }

    //Buying equipment
    public void BuyEquipment(string typeOfEquipment)
    {
        //Buying ammo
        if (typeOfEquipment == "Ammo" && ammoPrice <= currentGold)
        {
            currentAmmo = currentAmmo + ammoUnit;
            currentGold = currentGold - ammoPrice;
            audioManager.PlayConfirmSound();
        }
        //Buying Rockets
        else if (typeOfEquipment == "Rocket" && rocketPrice <= currentGold)
        {
            currentRockets = currentRockets + rocketUnit;
            currentGold = currentGold - rocketPrice;
            audioManager.PlayConfirmSound();
        }
        //Buying Fuel
        else if (typeOfEquipment == "Fuel" && fuelPrice <= currentGold)
        {
            currentFuel = currentFuel + fuelUnit;
            currentGold = currentGold - fuelPrice;
            audioManager.PlayConfirmSound();
        }
        else
            audioManager.PlayDenySound();

        DisplayEquipmentInHUD();
    }

    //Is the ship travelling right now?
    public void Travel()
    {
        isTravelling = uiManager.travelToggle.isOn;
        audioManager.PlayConfirmSound();
    }

    //Showing on the buttons if the current items are available
    public void ShowShopAvailability()
    {
        //Setting text color depending on availability
        if (currentGold >= ammoPrice)
            ammoShopText.color = availableColor;
        else 
            ammoShopText.color = unavailableColor;

        //The button is only possible to click if the player has enough gold
        ammoShopButton.interactable = currentGold >= ammoPrice;

        //Same here
        if (currentGold >= rocketPrice)
            rocketsShopText.color = availableColor;
        else 
            rocketsShopText.color = unavailableColor;

        //Etc
        rocketsShopButton.interactable = currentGold >= rocketPrice;

        if (currentGold >= fuelPrice)
            fuelShopText.color = availableColor;
        else 
            fuelShopText.color = unavailableColor;
        fuelShopButton.interactable = currentGold >= fuelPrice;

        if (currentGold >= shipPrice)
            shipShopText.color = availableColor;
        else 
            shipShopText.color = unavailableColor;
        shipShopButton.interactable = currentGold >= shipPrice;

        if (currentGold >= colonyPrice)
            colonyShopText.color = availableColor;
        else 
            colonyShopText.color = unavailableColor;
        colonyShopButton.interactable = currentGold >= colonyPrice;      
    }
}
