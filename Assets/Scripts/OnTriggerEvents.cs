using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerEvents : MonoBehaviour
{

    public bool isHealtaken;
    public bool isDamageUpTaken;
    public bool isSpeedTaken;

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            if (isHealtaken)
            {
                if(player.GetComponent<HealthScript>().health < player.GetComponent<HealthUI>().maxHealth)
                {
                    if(player.GetComponent<HealthUI>().maxHealth - player.GetComponent<HealthScript>().health >= 30)
                    {
                        player.GetComponent<HealthScript>().ApplyDamage(-30, false);
                        GetComponent<Animator>().SetTrigger("PickedUp");
                        transform.Find("Canvas").GetComponent<Animator>().SetTrigger("ObjectDone");
                        transform.Find("Canvas").transform.parent = null;
                        GetComponent<BoxCollider>().enabled = false;
                    }
                    else
                    {
                        float healing = player.GetComponent<HealthUI>().maxHealth - player.GetComponent<HealthScript>().health;
                        transform.Find("Canvas").transform.Find("Text").GetComponent<Text>().text = "Vida +"+(player.GetComponent<HealthUI>().maxHealth - player.GetComponent<HealthScript>().health);
                        player.GetComponent<HealthScript>().ApplyDamage(-healing, false);
                        GetComponent<Animator>().SetTrigger("PickedUp");
                        transform.Find("Canvas").GetComponent<Animator>().SetTrigger("ObjectDone");
                        transform.Find("Canvas").transform.parent = null;
                        GetComponent<BoxCollider>().enabled = false;
                    }
                    
                }
            }

            if (isDamageUpTaken)
            {
                if (player.transform.Find("Cone").transform.gameObject.activeInHierarchy)
                {
                    if (player.transform.Find("Cone").transform.gameObject.GetComponent<Vision>().isGun)
                    {
                        transform.Find("Canvas").GetComponent<Animator>().SetTrigger("ObjectDone");
                        transform.Find("Canvas").transform.parent = null;
                        player.transform.Find("Cone").transform.gameObject.GetComponent<Vision>().gunDamage += 2;
                    }

                    if (player.transform.Find("Cone").transform.gameObject.GetComponent<Vision>().isShotGun)
                    {
                        transform.Find("Canvas").GetComponent<Animator>().SetTrigger("ObjectDone");
                        transform.Find("Canvas").transform.parent = null;
                        player.transform.Find("Cone").transform.gameObject.GetComponent<Vision>().shotGunDamage += 2;
                    }

                    if (player.transform.Find("Cone").transform.gameObject.GetComponent<Vision>().isRifle)
                    {
                        transform.Find("Canvas").transform.Find("Text").GetComponent<Text>().text = "Daño +5";
                        transform.Find("Canvas").GetComponent<Animator>().SetTrigger("ObjectDone");
                        transform.Find("Canvas").transform.parent = null;
                        player.transform.Find("Cone").transform.gameObject.GetComponent<Vision>().shotGunDamage += 5;
                    }

                    GetComponent<Animator>().SetTrigger("PickedUp");
                    GetComponent<BoxCollider>().enabled = false;
                }
                else
                {
                    transform.Find("Canvas").transform.Find("Text").GetComponent<Text>().text = "Daño +5";
                    transform.Find("Canvas").GetComponent<Animator>().SetTrigger("ObjectDone");
                    transform.Find("Canvas").transform.parent = null;
                    player.GetComponent<Pattack>().playerAttackDamage += 5;
                    GetComponent<Animator>().SetTrigger("PickedUp");
                    GetComponent<BoxCollider>().enabled = false;
                }
                
            }

            if (isSpeedTaken)
            {
                player.GetComponent<CustomMovement>().moveSpeed += 2;
                transform.Find("Canvas").GetComponent<Animator>().SetTrigger("ObjectDone");
                transform.Find("Canvas").transform.parent = null;
                GetComponent<Animator>().SetTrigger("PickedUp");
                GetComponent<BoxCollider>().enabled = false;
            }
        }

    }

    public void Done()
    {
        gameObject.SetActive(false);
    }

}
