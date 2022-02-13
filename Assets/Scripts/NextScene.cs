using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int nextSceneNumb;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneNumb);
    }
}
