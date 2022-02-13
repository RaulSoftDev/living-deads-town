using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicationSet : MonoBehaviour
{
    public bool vsyincOn = true;
    public int FPS;

    GameObject vsyncText;
    
    void Awake()
    {
        //PlayerPrefs.DeleteKey("VsyncValue");

        if (PlayerPrefs.HasKey("VsyncValue"))
        {
            vsyincOn = bool.Parse(PlayerPrefs.GetString("VsyncValue"));
        }
        else
        {
            vsyincOn = false;
        }

        if (vsyincOn == null)
        {
            Debug.Log("Pues no");
        }
        
        Application.targetFrameRate = FPS;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        vsyncText = GameObject.Find("Button 3");

        Debug.Log(vsyincOn.ToString());
    }

    private void Update()
    {
        if (vsyincOn)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;

        if(vsyncText != null)
        {
            vsyncText.GetComponentInChildren<Text>().text = "VSync = " + vsyincOn.ToString();
        }
        
    }

    public void SetSync()
    {
        if (vsyincOn)
        {
            vsyincOn = false;
        }
        else
        {
            vsyincOn = true;
        }

        PlayerPrefs.SetString("VsyncValue", vsyincOn.ToString());
    }
}
