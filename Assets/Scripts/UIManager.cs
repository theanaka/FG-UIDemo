using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Menu Panels")]
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject storeMenu;
    [SerializeField] GameObject logMenu;

    [Header("HUD Elements")]
    public Toggle travelToggle;

    [Header("Scripts")]
    [SerializeField] AudioManager audioManager;

    void Start()
    {
        //Turning the menus off at the start of the game, in case they were left opened
        CloseAllMenus();
    }

    //Opening or closing the Pause Menu
    public void SetPauseMenuOpen(bool isOpen)
    {
        pauseMenu.SetActive(isOpen);
    }

    //Toggling the pause menu on/off depending on the current state
    public void TogglePauseMenuOpen()
    {
        if (!pauseMenu.activeSelf)
        {
            CloseAllMenus();
            SetPauseMenuOpen(true);
        }
        else 
            CloseAllMenus();

        audioManager.PlayStandardSound();
    }

    //Opening or closing the Settings Menu
    public void SetSettingsMenuOpen(bool isOpen)
    {
        settingsMenu.SetActive(isOpen);
        audioManager.PlayStandardSound();
    }

    //Opening or closing the Equipment Store Menu
    public void SetStoreMenuOpen(bool isOpen)
    {
        storeMenu.SetActive(isOpen);
    }

    //Toggling the store menu on/off depending on the current state
    public void ToggleStoreMenuOpen()
    {
        if (!storeMenu.activeSelf)
        {
            CloseAllMenus();
            SetStoreMenuOpen(true);
        }
        else 
            CloseAllMenus();

        audioManager.PlayStandardSound();
    }

    //Opening or closing the Log Menu
    public void SetLogMenuOpen(bool isOpen)
    {
        logMenu.SetActive(isOpen);
    }

    //Toggling the log menu on/off depending on the current state
    public void ToggleLogMenuOpen()
    {
        if (!logMenu.activeSelf)
        {
            CloseAllMenus();
            SetLogMenuOpen(true);
        }
        else 
            CloseAllMenus();

        audioManager.PlayStandardSound();
    }

    //Closing all menus, open or not
    public void CloseAllMenus()
    {
        SetPauseMenuOpen(false);
        SetSettingsMenuOpen(false);
        SetStoreMenuOpen(false);
        SetLogMenuOpen(false);
    }

    //Quitting the game (only possible in build, not inside Unity)
    public void QuitGame()
    {
        Application.Quit();

        audioManager.PlayStandardSound();
    }

}
