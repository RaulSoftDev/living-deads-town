using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OutLimitScript : MonoBehaviour
{
    public Transform sign;
    GameObject playerPos;

    public bool followZ;

    public float smoothTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
       
    }

    void FixedUpdate()
    {
        if (!followZ)
        {
            sign.position = Vector3.Lerp(sign.position, new Vector3(playerPos.transform.position.x, sign.position.y, sign.position.z), smoothTime * Time.fixedDeltaTime);
        }
        else
        {
            sign.position = new Vector3(sign.position.x, sign.position.y, playerPos.transform.position.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }
}
