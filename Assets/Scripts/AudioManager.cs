using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Audio Sources")]
    public List<AudioSource> audioSources;

    [Header("Audio Clips")]
    [SerializeField] AudioClip standardUISound;
    [SerializeField] AudioClip confirmUISound;
    [SerializeField] AudioClip denyUISound;

    //Playing the standard button sound
    public void PlayStandardSound()
    {
        //Randomizing the pitch of the audio source, to make the ear less tired of the repeating SFX
        audioSources[1].pitch = Random.Range (0.95f, 1.05f);
        //Sinding off a one-shot sound
        audioSources[1].PlayOneShot(standardUISound);
    }

    //Playing the confirm button sound
    public void PlayConfirmSound()
    {
        //Randomizing the pitch of the audio source, to make the ear less tired of the repeating SFX
        audioSources[1].pitch = Random.Range (0.95f, 1.05f);
        //Sinding off a one-shot sound
        audioSources[1].PlayOneShot(confirmUISound);
    }

    //Playing the deny button sound
    public void PlayDenySound()
    {
        //Randomizing the pitch of the audio source, to make the ear less tired of the repeating SFX
        audioSources[1].pitch = Random.Range (0.95f, 1.05f);
        //Sinding off a one-shot sound
        audioSources[1].PlayOneShot(denyUISound);
    }
}
