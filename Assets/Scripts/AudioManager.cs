using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioClip bso1;
    public AudioClip bso2;
    public AudioClip bso3;
    public AudioClip bso4;
    public AudioClip bso5;

    public AudioMixer mainMixer;

    private void Awake()
    {
        if (PlayerPrefs.GetString("Scene1") == true.ToString())
        {
            GetComponent<AudioSource>().PlayOneShot(bso1);
        }

        if (PlayerPrefs.GetString("Scene2") == true.ToString())
        {
            GetComponent<AudioSource>().PlayOneShot(bso2);
        }

        if (PlayerPrefs.GetString("Scene3") == true.ToString())
        {
            GetComponent<AudioSource>().PlayOneShot(bso3);
        }

        if (PlayerPrefs.GetString("Scene4") == true.ToString())
        {
            GetComponent<AudioSource>().PlayOneShot(bso4);
        }

        if (PlayerPrefs.GetString("Scene5") == true.ToString())
        {
            GetComponent<AudioSource>().PlayOneShot(bso5);
        }

    }
}
