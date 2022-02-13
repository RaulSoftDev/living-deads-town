using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineManager : MonoBehaviour
{

    private Image actionButtonImage;
    private Button actionButton;

    public GameObject menuOn;
    public GameObject screenBat;

    private Button buttonA;
    private Button buttonB;
    private FixedJoystick joystickButton;

    // Start is called before the first frame update
    void Start()
    {
        actionButton = GameObject.Find("C").GetComponent<Button>();
        actionButtonImage = GameObject.Find("C").GetComponent<Image>();
        buttonA = GameObject.Find("A").GetComponent<Button>();
        //buttonB = GameObject.Find("B").GetComponent<Button>();
        joystickButton = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!menuOn.activeInHierarchy)
            {
                actionButtonImage.enabled = true;
                actionButton.interactable = true;
            } 
        }
    }

    private void OnTriggerExit(Collider other2)
    {
        if(other2.tag == "Player")
        {
            actionButtonImage.enabled = false;
            actionButton.interactable = false;
        }
    }

    public void MachineOn()
    {
        actionButton.interactable = false;
        buttonA.interactable = false;
        //buttonB.interactable = false;
        joystickButton.DeadZone = 100;
        menuOn.SetActive(true);
        screenBat.SetActive(true);
    }

    public void MachineOff()
    {
        actionButton.interactable = true;
        buttonA.interactable = true;
        //buttonB.interactable = true;
        joystickButton.DeadZone = 0;
        menuOn.SetActive(false);
        screenBat.SetActive(false);
    }
}
