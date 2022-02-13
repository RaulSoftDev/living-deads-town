using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    float lvlToAdd;
    float currentScene;
    bool isScene2Unlocked;
    bool isScene3Unlocked;
    bool isScene4Unlocked;
    bool isScene5Unlocked;

    private void Start()
    {
        if (PlayerPrefs.HasKey("LvlToAdd"))
        {
            lvlToAdd = PlayerPrefs.GetFloat("LvlToAdd");
        }
        else
        {
            lvlToAdd = 0;
        }

        if (PlayerPrefs.HasKey("Level2"))
        {
            isScene2Unlocked = System.Convert.ToBoolean(PlayerPrefs.GetString("Level2"));
        }
        else
        {
            isScene2Unlocked = false;
        }

        if (PlayerPrefs.HasKey("Level3"))
        {
            isScene3Unlocked = System.Convert.ToBoolean(PlayerPrefs.GetString("Level3"));
        }
        else
        {
            isScene3Unlocked = false;
        }

        if (PlayerPrefs.HasKey("Level4"))
        {
            isScene4Unlocked = System.Convert.ToBoolean(PlayerPrefs.GetString("Level4"));
        }
        else
        {
            isScene4Unlocked = false;
        }

        if (PlayerPrefs.HasKey("Level5"))
        {
            isScene5Unlocked = System.Convert.ToBoolean(PlayerPrefs.GetString("Level5"));
        }
        else
        {
            isScene5Unlocked = false;
        }

        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadMainMenu()
    {
        switch (lvlToAdd)
        {
            case 0:
                if(currentScene == 8 && !isScene2Unlocked)
                {
                    PlayerPrefs.SetFloat("LvlToAdd", 1);
                    PlayerPrefs.SetString("BoolUnlock", "True");
                }
                break;

            case 1:
                if (currentScene == 9 && !isScene3Unlocked)
                {
                    PlayerPrefs.SetFloat("LvlToAdd", 2);
                    PlayerPrefs.SetString("BoolUnlock", "True");
                }
                break;

            case 2:
                if (currentScene == 10 && !isScene4Unlocked)
                {
                    PlayerPrefs.SetFloat("LvlToAdd", 3);
                    PlayerPrefs.SetString("BoolUnlock", "True");
                }
                break;

            case 3:
                if (currentScene == 11 && !isScene5Unlocked)
                {
                    PlayerPrefs.SetFloat("LvlToAdd", 4);
                    PlayerPrefs.SetString("BoolUnlock", "True");
                }
                break;

            default:
                break;
        }

        SceneManager.LoadScene(13);
    }
}
