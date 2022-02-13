using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroScene : MonoBehaviour
{
    public float seconds;
    public float minutes;

    bool timeActive;

    private void Update()
    {
        Clock();
        timeActive = true;
    }

    void Clock()
    {
        if (timeActive)
        {
            seconds += Time.deltaTime;

            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
            }
        }
        
    }

}
