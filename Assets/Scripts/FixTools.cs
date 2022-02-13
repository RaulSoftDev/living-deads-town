using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixTools : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //if an enemy appears inside, delete it
        if(other.tag == "Enemy")
        {
            //Destroy(other);
        }
    }
}
