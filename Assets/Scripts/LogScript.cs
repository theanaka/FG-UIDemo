using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogScript : MonoBehaviour
{

    [Header("Log Elements")]
    [SerializeField] TMP_Text inputText;  
    [SerializeField] TMP_Text logDisplayText;

    [Header("Stardate")]
    [SerializeField] int stardate = 1338;

    [Header("Scripts")]
    [SerializeField] AudioManager audioManager;

    //Sending in the text from the input field
    public void SubmitLogText()
    {
        //Adding the text from input field to the display text, after first adding a line break
        //Also adding a stardate, just because why not
        logDisplayText.text = logDisplayText.text + "\nStardate " + stardate.ToString() + ": " + inputText.text;

        //Increasing current stardate by a random value
        stardate = stardate + Random.Range(1,10);

        audioManager.PlayConfirmSound();
    }
}
