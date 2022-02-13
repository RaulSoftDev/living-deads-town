using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraHealth : MonoBehaviour
{
    private Transform healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
    }

    void FixedUpdate()
    {
        Quaternion savedRotation = Quaternion.Euler(-269.703f, 0, 0);
        transform.rotation = savedRotation;

    }
}
