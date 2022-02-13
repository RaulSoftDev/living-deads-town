using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDeleter : MonoBehaviour
{
    public GameObject[] enemies;
    public Vision weaponScript;

    void Start()
    {
        
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        StartCoroutine(DeleteProtocol());
    }

    IEnumerator DeleteProtocol()
    {
        foreach (GameObject item in enemies)
        {
            if (item.activeInHierarchy)
            {
                if (item.GetComponent<AI_Navigation>().isDeath)
                {
                    if(weaponScript != null && weaponScript.isShotGun)
                    {
                        weaponScript.targets.Remove(item);
                    }
                    yield return new WaitForSeconds(1.25f);
                    Destroy(item);
                }
                else
                {
                    yield break;
                }
            }
            
        }

        yield break;
    }
}
