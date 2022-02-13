using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostGameEvents : MonoBehaviour
{
    private void Update()
    {
        Debug.Log(System.Convert.ToBoolean(PlayerPrefs.GetString("UnlockL3")));
    }

    public void UnlockLevel()
    {
        if (GameObject.Find("EventManager").GetComponent<EventManager>().scene1Active)
        {
            PlayerPrefs.SetString("UnlockL2", true.ToString());
        }
        else if (GameObject.Find("EventManager").GetComponent<EventManager>().scene2Active)
        {
            PlayerPrefs.SetString("UnlockL3", true.ToString());
        }
        else if (GameObject.Find("EventManager").GetComponent<EventManager>().scene3Active)
        {
            PlayerPrefs.SetString("UnlockL4", true.ToString());
        }
        else if (GameObject.Find("EventManager").GetComponent<EventManager>().scene4Active)
        {
            PlayerPrefs.SetString("UnlockL5", true.ToString());
        }
    }
}
