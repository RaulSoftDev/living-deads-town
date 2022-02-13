using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuActive : MonoBehaviour
{
    private Button button;
    private GameObject weapon1;
    public bool IsWeaponActive = false;
    public bool ActiveButton = false;
    private MachineManager materialsMenu;
    private MaterialsManager woodCounter;
    private Image bat;



    void Start()
    {
        button = GetComponent<Button>();
        weapon1 = GameObject.Find("w_baseballbat");
        woodCounter = GameObject.Find("ListManager").GetComponent<MaterialsManager>();
        materialsMenu = GameObject.Find("Machine").GetComponent<MachineManager>();
        bat = GameObject.Find("Icono").GetComponent<Image>();
        //SetInactiveWeaponButton();
    }


    void Update()
    {
       
    }

    void SetActiveWeaponButton()
    {
        button.interactable = true;
        bat.enabled = true;
    }

    void SetInactiveWeaponButton()
    {
        button.interactable = false;
        weapon1.SetActive(false);
        bat.enabled = false;
    }

    public void WeaponOn()
    {
        IsWeaponActive = true;

        weapon1.SetActive(true);
    }

    public void ButtonActivated()
    {
        if (IsWeaponActive)
        {
            IsWeaponActive = false;
            weapon1.SetActive(false);
        }
    }

    public void CountWood()
    {
        if(woodCounter.countWood >= 1)
        {
            materialsMenu.MachineOff();
            SetActiveWeaponButton();
            woodCounter.countWood--;

        }
        else
        {
            Debug.Log("Hacen falta más materiales");
        }
    }
}
