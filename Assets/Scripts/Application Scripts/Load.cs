using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    GameObject mainCanvas;
    GameObject playMenu;
    GameObject optionsMenu;
    GameObject optionsPanel;

    public GameObject levelsMenu;

    bool isActive;

    private void Awake()
    {
        mainCanvas = GameObject.Find("Canvas");
        playMenu = MyUtils.FindInChildrenIncludingInactive(mainCanvas, "Niveles");
        optionsMenu = mainCanvas.transform.Find("MainMenu").transform.Find("Opciones").transform.gameObject;
        optionsPanel = MyUtils.FindInChildrenIncludingInactive(optionsMenu, "Audios");

        isActive = false;
    }

    public void PlayMenu()
    {
        mainCanvas.transform.Find("MainMenu").transform.gameObject.SetActive(false);
        playMenu.SetActive(true);
    }

    public void OptionsMenuActive()
    {
        if(optionsPanel != null)
        {
            if (!isActive)
            {
                optionsPanel.SetActive(true);
                optionsMenu.GetComponent<Animator>().SetBool("OptionsOn", true);
                isActive = true;
            }
            else
            {
                StartCoroutine(OptionsPanelTiming());
            }
        }
    }

    IEnumerator OptionsPanelTiming()
    {
        optionsMenu.GetComponent<Animator>().SetBool("OptionsOn", false);
        yield return new WaitForSeconds(optionsMenu.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1);
        optionsPanel.SetActive(false);
        isActive = false;
    }

    public void CloseLevelsMenu()
    {
        levelsMenu.SetActive(false);
    }

}
