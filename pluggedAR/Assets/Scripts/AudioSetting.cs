using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : MonoBehaviour
{

    private static readonly string BackgroundPref = "BackgroundPref", soundEffectPref = "soundEffectPref";

    private float backgroundFloat, soundEffectFloat;

    public AudioSource backgroundAudio, soundAudio;

    private void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        backgroundAudio.volume = backgroundFloat;

        soundEffectFloat = PlayerPrefs.GetFloat(soundEffectPref);
        soundAudio.volume = soundEffectFloat;

    }
}
