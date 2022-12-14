using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsScript : MonoBehaviour
{

    [Header("Video Settings")]
    [SerializeField] Toggle fullscreenToggle;

    [Header("Audio Settings")]
    [SerializeField] float currentVolume;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TMP_Text currentVolumeText;

    [Header("Language Settings")]
    [SerializeField] int currentLanguage;
    [SerializeField] TMP_Dropdown languageDropdown;

    [Header("Scripts")]
    [SerializeField] AudioManager audioManager;

    //Setting fullscreen on and off
    public void SetFullScreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    //Setting the volume of the audio sources
    public void SetVolume()
    {
        //Getting the desired value from the slider
        currentVolume = volumeSlider.value;

        //Applying value to all audio sources
        foreach (AudioSource _as in audioManager.audioSources)
        {
            _as.volume = currentVolume;
        }

        //Showing the current volume in the UI, without decimals
        currentVolumeText.text = ((int)(currentVolume * 100)).ToString();
    }

    //Setting current language
    //Note:  This would have to be hooked up to a loc system, in order for the tex to change in the UI
    public void SetLanguage()
    {
        currentLanguage = languageDropdown.value;
    }

}
