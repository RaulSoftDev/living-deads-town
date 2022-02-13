using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    public Slider musicVolSlider;
    public Slider effectsSlider;

    public void SetMusicAudio(float musicVolume)
    {
        mainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetEffectsAudio(float effectsVolume)
    {
        mainAudioMixer.SetFloat("EffectsVolume", Mathf.Log10(effectsVolume) * 20);
        PlayerPrefs.SetFloat("EffectsVolume", effectsVolume);
    }

    private void Start()
    {
        AudioEnabled();
    }

    void AudioEnabled()
    {
        if(PlayerPrefs.HasKey("MusicVolume") && PlayerPrefs.HasKey("EffectsVolume"))
        {
            musicVolSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
            effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
        }
        else
        {
            musicVolSlider.value = 0.5f;
            effectsSlider.value = 0.5f;
        }
        
    }
}
