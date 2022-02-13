using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    GameObject[] enemies;

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
    }

    public void PauseMenuOn()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(true);
        Time.timeScale = 0;
        /*foreach (GameObject item in enemies)
        {
            item.GetComponent<AI_Navigation>().playerTrans = null;
            item.GetComponent<Animator>().SetBool("Punch", false);
            item.GetComponent<NavMeshAgent>().isStopped = true;
        }*/
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1;
        /*foreach (GameObject item in enemies)
        {
            item.GetComponent<AI_Navigation>().playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            item.GetComponent<NavMeshAgent>().isStopped = false;
        }*/
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(13);
    }
}
