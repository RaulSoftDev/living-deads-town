using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Loading : MonoBehaviour
{
    float sceneID;
    public AudioClip[] levelsMusic;
    public AudioMixer mainAudioMixer;
    AudioSource audioSource;
    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();

        SetVolumes();
    }

    // Update is called once per frame
    void Update()
    {
        sceneID = SceneManager.GetActiveScene().buildIndex;
        CurrentMusic();
    }

    void CurrentMusic()
    {
        switch (sceneID)
        {
            case 0:
                if (!isPlaying)
                {
                    audioSource.clip = levelsMusic[0];
                    audioSource.Play();
                    isPlaying = true;
                }
                break;

            case 3:
                if (isPlaying)
                {
                    audioSource.clip = levelsMusic[1];
                    audioSource.Play();
                    isPlaying = false;
                }
                break;

            case 4:
                if (isPlaying)
                {
                    audioSource.clip = levelsMusic[2];
                    audioSource.Play();
                    isPlaying = false;
                }
                break;

            case 5:
                if (isPlaying)
                {
                    audioSource.clip = levelsMusic[3];
                    audioSource.Play();
                    isPlaying = false;
                }
                break;

            case 6:
                if (isPlaying)
                {
                    audioSource.clip = levelsMusic[4];
                    audioSource.Play();
                    isPlaying = false;
                }
                break;

            case 7:
                if (isPlaying)
                {
                    audioSource.clip = levelsMusic[5];
                    audioSource.Play();
                    isPlaying = false;
                }
                break;

            case 13:
                if (isPlaying)
                {
                    audioSource.clip = levelsMusic[0];
                    audioSource.Play();
                    isPlaying = false;
                }
                break;

            default:
                break;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (audioSource.isPlaying)
        {
            isPlaying = true;
        }
    }

    void SetVolumes()
    {
        mainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20);
        mainAudioMixer.SetFloat("EffectsVolume", Mathf.Log10(PlayerPrefs.GetFloat("EffectsVolume")) * 20);
    }
}
