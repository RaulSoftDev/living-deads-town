using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCallScript : MonoBehaviour
{
    public bool gunReady;

    // Start is called before the first frame update
    void Start()
    {
        gunReady = true;   
    }

    public void GunOnLoad()
    {
        if (!gunReady)
        {
            gunReady = true;
        }
    }
}
