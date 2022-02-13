using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditor : MonoBehaviour
{
    public GameObject[] levels;
    public float levelToAdd;
    public bool levelUnlocked;
    public float levelToUnlock;

    private void Awake()
    {
        PlayerPrefs.DeleteKey("LvlToAdd");
        PlayerPrefs.DeleteKey("UnlockedLevel");
        PlayerPrefs.DeleteKey("BoolUnlock");
        PlayerPrefs.DeleteKey("Level2");
        PlayerPrefs.DeleteKey("Level3");
        PlayerPrefs.DeleteKey("Level4");
        PlayerPrefs.DeleteKey("Level5");
        if (PlayerPrefs.HasKey("LvlToAdd"))
        {
            levelToAdd = PlayerPrefs.GetFloat("LvlToAdd");
        }
        else
        {
            levelToAdd = 0;
        }

        if (PlayerPrefs.HasKey("UnlockedLevel"))
        {
            levelToUnlock = PlayerPrefs.GetFloat("UnlockedLevel");
            UnlockCurrentLevel();
        }
        else
        {
            levelToUnlock = 0;
        }

        if (PlayerPrefs.HasKey("BoolUnlock"))
        {
            levelUnlocked = System.Convert.ToBoolean(PlayerPrefs.GetString("BoolUnlock"));
        }
        else
        {
            levelUnlocked = false;
        } 
    }
    
    void Start()
    {
        LevelAdd();       
    }

    void LevelAdd()
    {
        switch (levelToAdd)
        {
            case 1:
                if (levelUnlocked)
                {
                    GetComponent<Animator>().enabled = true;
                    GetComponent<Animator>().SetBool("Level2Unlocked", true);
                    StartCoroutine(DeactivateAnimation("Level2Unlocked"));
                    levelUnlocked = false;
                    PlayerPrefs.SetFloat("UnlockedLevel", 1);
                }
                break;

            case 2:
                if (levelUnlocked)
                {
                    GetComponent<Animator>().enabled = true;
                    GetComponent<Animator>().SetBool("Level3Unlocked", true);
                    StartCoroutine(DeactivateAnimation("Level3Unlocked"));
                    levelUnlocked = false;
                    PlayerPrefs.SetFloat("UnlockedLevel", 2);
                }
                break;

            case 3:
                if (levelUnlocked)
                {
                    GetComponent<Animator>().enabled = true;
                    GetComponent<Animator>().SetBool("Level4Unlocked", true);
                    StartCoroutine(DeactivateAnimation("Level4Unlocked"));
                    levelUnlocked = false;
                    PlayerPrefs.SetFloat("UnlockedLevel", 3);
                }
                break;

            case 4:
                if (levelUnlocked)
                {
                    GetComponent<Animator>().enabled = true;
                    GetComponent<Animator>().SetBool("Level5Unlocked", true);
                    StartCoroutine(DeactivateAnimation("Level5Unlocked"));
                    levelUnlocked = false;
                    PlayerPrefs.SetFloat("UnlockedLevel", 4);
                }
                break;

            default:
                break;
        }
    }

    IEnumerator DeactivateAnimation(string animationBool)
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animator>().SetBool(animationBool, false);
    }

    void UnlockCurrentLevel()
    {
        switch (levelToUnlock)
        {
            case 1:
                levels[0].GetComponent<Button>().interactable = true;
                break;

            case 2:
                levels[0].GetComponent<Button>().interactable = true;
                levels[1].GetComponent<Button>().interactable = true;
                break;

            case 3:
                levels[0].GetComponent<Button>().interactable = true;
                levels[1].GetComponent<Button>().interactable = true;
                levels[2].GetComponent<Button>().interactable = true;
                break;

            case 4:
                levels[0].GetComponent<Button>().interactable = true;
                levels[1].GetComponent<Button>().interactable = true;
                levels[2].GetComponent<Button>().interactable = true;
                levels[3].GetComponent<Button>().interactable = true;
                break;

            default:
                break;
        }
    }

    void NewLevel2()
    {
        PlayerPrefs.SetString("Level2", "True");
        PlayerPrefs.SetString("BoolUnlock", "False");
    }

    void NewLevel3()
    {
        PlayerPrefs.SetString("Level3", "True");
        PlayerPrefs.SetString("BoolUnlock", "False");
    }

    void NewLevel4()
    {
        PlayerPrefs.SetString("Level4", "True");
        PlayerPrefs.SetString("BoolUnlock", "False");
    }

    void NewLevel5()
    {
        PlayerPrefs.SetString("Level5", "True");
        PlayerPrefs.SetString("BoolUnlock", "False");
    }
}
