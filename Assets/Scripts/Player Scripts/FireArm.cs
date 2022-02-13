using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArm : MonoBehaviour
{
    public float damage;
    public float range;
    public float gunRadius;

    Transform origin;
    Animator playerAN;
    Transform gun;


    // Start is called before the first frame update
    void Start()
    {
        playerAN = GetComponent<Animator>();
        origin = GetComponent<Transform>();
        gun = GameObject.FindGameObjectWithTag("Bat").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GunfireAnim();
    }

    IEnumerator OnCompleteAttackAnimation()
    {
        playerAN.SetBool("Runfire", true);
        Shoot();

        yield return null;

        //Now wait for them to finish
        while (playerAN.GetCurrentAnimatorStateInfo(0).IsTag("1"))
        {
            yield return null;
        }
    }

    void GunfireAnim()
    {
        if (Input.GetButtonDownMobile("Fire1") || Input.GetKeyDown(KeyCode.M))
        {
            playerAN.SetBool("Fire", true);
            Shoot();
        }
        else
        {
            playerAN.SetBool("Fire", false);
        }

        if (Input.GetButtonMobile("Fire1") || Input.GetButton("Fire2"))
        {
            {
                //StartCoroutine("OnCompleteAttackAnimation");
            }

        }
        if (Input.GetButtonUpMobile("Fire1") || Input.GetButtonUp("Fire2"))
        {
            //playerAN.SetBool("Runfire", false);
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Vector3 forward = origin.TransformDirection(new Vector3(0, gun.position.y, 1)) * range;
        Debug.DrawRay(origin.position, origin.forward, Color.red);
        if(Physics.Raycast(origin.position, origin.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            AI_Navigation target = hit.transform.GetComponent<AI_Navigation>();
            if(target != null)
            {
                target.GunAttack(damage);
            }
        }
    }
}
