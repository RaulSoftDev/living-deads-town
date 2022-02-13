using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPunch : MonoBehaviour
{
    public GameObject material;
    private SphereCollider sphereCollider;
    private BoxCollider boxCollider;
    private Rigidbody childRigidbody;

    private void Start()
    {
        sphereCollider = material.GetComponent<SphereCollider>();
        boxCollider = material.GetComponent<BoxCollider>();
        childRigidbody = material.GetComponent<Rigidbody>();
        DisableCollider();
    }

    private void OnTriggerEnter(Collider detection)
    {
        if(detection.tag == "LeftArm")
        {
            EnableCollider();
        }
    }

    void DisableCollider()
    {
        sphereCollider.enabled = false;
    }

    void EnableCollider()
    {
        StartCoroutine("Exposed");
    }

    IEnumerator Exposed()
    {
        if(material != null)
        {
            material.SetActive(true);
            material.transform.parent = null;
        }
        yield return new WaitForSecondsRealtime(2.0f);
        if(childRigidbody != null)
        {
            childRigidbody.isKinematic = true;
        }
        if(boxCollider != null)
        {
            boxCollider.isTrigger = true;
        }
        if(sphereCollider != null)
        {
            sphereCollider.enabled = true;
        }
    }
}
