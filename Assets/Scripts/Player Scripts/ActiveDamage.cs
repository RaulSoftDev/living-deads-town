using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDamage : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    private Animator playerAN;

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        //playerAN = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDownMobile("Fire1") || Input.GetKeyDown(KeyCode.M))
        {
            //StartCoroutine("DamageEnabled");
        }
    }

    IEnumerator DamageEnabled()
    {
        capsuleCollider.enabled = true;
        yield return new WaitForSeconds(1.25f);
        capsuleCollider.enabled = false;
    }

}
