using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private bool loadScene1;
    [SerializeField] private bool loadScene2;
    [SerializeField] private bool loadScene3;
    [SerializeField] private bool loadScene4;
    [SerializeField] private bool loadScene5;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        if (loadScene1 && !loadScene2 && !loadScene3 && !loadScene4 && !loadScene5)
        {
            FindObjectOfType<ProgressSceneLoader>().LoadScene(sceneToLoad);
        }

        if (loadScene2 && !loadScene1 && !loadScene3 && !loadScene4 && !loadScene5)
        {
            FindObjectOfType<ProgressSceneLoader>().LoadScene(sceneToLoad);
        }


        if (loadScene3 && !loadScene1 && !loadScene2 && !loadScene4 && !loadScene5)
        {
            PlayerPrefs.SetString("Scene3", true.ToString());
            gameObject.SetActive(false);
            FindObjectOfType<ProgressSceneLoader>().LoadScene(sceneToLoad);
        }


        if (loadScene4 && !loadScene1 && !loadScene2 && !loadScene3 && !loadScene5)
        {
            PlayerPrefs.SetString("Scene4", true.ToString());
            gameObject.SetActive(false);
            FindObjectOfType<ProgressSceneLoader>().LoadScene(sceneToLoad);
        }

        if (loadScene5 && !loadScene1 && !loadScene2 && !loadScene3 && !loadScene4)
        {
            PlayerPrefs.SetString("Scene5", true.ToString());
            gameObject.SetActive(false);
            FindObjectOfType<ProgressSceneLoader>().LoadScene(sceneToLoad);
        }

        if (!loadScene5 && !loadScene1 && !loadScene2 && !loadScene3 && !loadScene4)
        {
            gameObject.SetActive(false);
            FindObjectOfType<ProgressSceneLoader>().LoadScene(sceneToLoad);
        }

    }
}
