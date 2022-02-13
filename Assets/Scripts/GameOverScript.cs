using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public int finalSceneToLoad;

    public void LoadFinalScene()
    {
        SceneManager.LoadScene(finalSceneToLoad);
    }
}
