using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameLoader : MonoBehaviour
{
    public GameObject[] backside;
    GameObject parent;

    // Start is called before the first frame update
    void Awake()
    {
        parent = GameObject.Find("Loader");
        backside = GameObject.FindGameObjectsWithTag("Entorno");

        foreach (GameObject item in backside)
        {
            item.AddComponent<DisableIfFarAway>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
