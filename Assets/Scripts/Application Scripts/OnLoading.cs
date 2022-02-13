using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLoading : MonoBehaviour
{

    GameObject playerBat;
    GameObject playerKatana;

    public bool playerBatOn;
    public bool playerKatanaOn;

    private void Awake()
    {
        //ChangeSkin();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ChangeSkin()
    {
        playerBat = MyUtils.FindInChildrenIncludingInactive(gameObject, "Player_Bat");
        playerKatana = MyUtils.FindInChildrenIncludingInactive(gameObject, "Player_Katana");

        if (playerBatOn && !playerKatanaOn)
        {
            playerBat.SetActive(true);
            playerKatana.SetActive(false);
        }

        if (playerKatanaOn && !playerBatOn)
        {
            playerKatana.SetActive(true);
            playerBat.SetActive(false);
        }
    }
}
