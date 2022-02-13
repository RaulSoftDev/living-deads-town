using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneActivator : MonoBehaviour
{
    public bool scene1;
    public bool scene2;
    public bool scene3;
    public bool scene4;
    public bool scene5;

    public static SceneActivator control;

    private void Awake()
    {
        control = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (scene1)
        {
            GameObject.Find("EventManager").GetComponent<EventManager>().scene1Active = true;
        }
    }
}
