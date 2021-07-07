using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref", soundEffectPref = "soundEffectPref";

    private int firstPlayInt;
    private float backgroundFloat, soundEffectFloat;

    public Slider backgroundSlider, soundEffectSlider;
    public AudioSource backgroundAudio, soundAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0)
        {
            backgroundFloat = .25f;
            backgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);

            soundEffectFloat = .75f;
            soundEffectSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(soundEffectPref, soundEffectFloat);

            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat= PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;

            soundEffectFloat = PlayerPrefs.GetFloat(soundEffectPref);
            soundEffectSlider.value = soundEffectFloat;
        }
    }

    public void saveSoundSetting()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(soundEffectPref, soundEffectSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            saveSoundSetting();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
        soundAudio.volume = soundEffectSlider.value;

    }
}
