using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOff : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject blackScreenPlayer;

    void CameraSwitch()
    {
        transform.GetComponent<Camera>().enabled = false;
        transform.GetComponent<AudioListener>().enabled = false;
        playerCamera.GetComponent<AudioListener>().enabled = true;
        playerCamera.GetComponent<Camera>().enabled = true;

        playerCamera.GetComponent<Animator>().SetTrigger("InterfaceOn");
    }

    void BlackScreenOn()
    {
        
    }
}
