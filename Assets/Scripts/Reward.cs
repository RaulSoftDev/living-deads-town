using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    float minutes;
    float seconds;

    public Text timerText;
    public GameObject[] rewards;
    public GameObject[] price;
    public GameObject exitAnimation;

    void Start()
    {
        TimerOnSet();
        SetReward();
    }

    void TimerOnSet()
    {
        if(PlayerPrefs.HasKey("Minutes") & PlayerPrefs.HasKey("Seconds"))
        {
            minutes = PlayerPrefs.GetFloat("Minutes");
            seconds = PlayerPrefs.GetFloat("Seconds");

            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
        else
        {
            timerText.text = "XX:XX";
        }
    }

    void SetReward()
    {
        if (PlayerPrefs.HasKey("Minutes") & PlayerPrefs.HasKey("Seconds"))
        {
            if (minutes <= 2)
            {
                rewards[0].SetActive(true);
                price[0].SetActive(true);
            }
            else if (minutes > 2 & minutes <= 4)
            {
                rewards[1].SetActive(true);
                price[1].SetActive(true);
            }
            else
            {
                rewards[2].SetActive(true);
                price[2].SetActive(true);
            }
        }
        else
        {
            Debug.Log("No Reward Available");
        }
    }

    public void ExitFromGame()
    {
        exitAnimation.GetComponent<Animator>().SetTrigger("Exit");
    }

}
