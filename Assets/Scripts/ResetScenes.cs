using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetScenes : MonoBehaviour
{
    public GameObject levels;
    public GameObject credits;

    public bool level2Unlock;
    public bool level3Unlock;
    public bool level4Unlock;
    public bool level5Unlock;

    private void Awake()
    {
        PlayerPrefs.SetString("Scene1", false.ToString());
        PlayerPrefs.SetString("Scene2", false.ToString());
        PlayerPrefs.SetString("Scene3", false.ToString());
        PlayerPrefs.SetString("Scene4", false.ToString());
        PlayerPrefs.SetString("Scene5", false.ToString());

        if (PlayerPrefs.GetString("UnlockL2") == true.ToString())
        {
            level2Unlock = System.Convert.ToBoolean(PlayerPrefs.GetString("UnlockL2"));
        }

        if (PlayerPrefs.GetString("UnlockL3") == true.ToString())
        {
            level3Unlock = System.Convert.ToBoolean(PlayerPrefs.GetString("UnlockL3"));
        }

        if (PlayerPrefs.GetString("UnlockL4") == true.ToString())
        {
            level4Unlock = System.Convert.ToBoolean(PlayerPrefs.GetString("UnlockL4"));
        }

        if (PlayerPrefs.GetString("UnlockL5") == true.ToString())
        {
            level5Unlock = System.Convert.ToBoolean(PlayerPrefs.GetString("UnlockL5"));
        }
    }

    private void Start()
    {
        if (level2Unlock)
        {
            levels.transform.Find("Nivel 2").transform.GetComponent<Button>().interactable = true;
        }

        if (level3Unlock)
        {
            levels.transform.Find("Nivel 3").transform.GetComponent<Button>().interactable = true;
        }

        if (level4Unlock)
        {
            levels.transform.Find("Nivel 4").transform.GetComponent<Button>().interactable = true;
        }

        if (level5Unlock)
        {
            levels.transform.Find("Nivel 5").transform.GetComponent<Button>().interactable = true;
        }
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }
}
