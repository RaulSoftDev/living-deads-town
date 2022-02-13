using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public GameObject zombieOriginal;
    GameObject zombieClone;
    GameObject[] zombieArray;

    float zombieNum;
    public float customZombieSpeed;
    public float customDistance;

    private void Update()
    {
        if(zombieClone != null)
        {
            zombieClone.transform.localScale = GameObject.FindGameObjectWithTag("Player").transform.localScale;
            zombieArray = GameObject.FindGameObjectsWithTag("Enemy");
        }
        else
        {
            return;
        }
        

        foreach (GameObject zombie in zombieArray)
        {
            zombie.GetComponent<AI_Navigation>().speed = customZombieSpeed;
            zombie.GetComponent<AI_Navigation>().distanceToPlayer = customDistance;
        }
    }

    public void SpawnOnButton()
    {
        Debug.Log("Spawn");
        zombieClone = Instantiate(zombieOriginal, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
        zombieClone.name = "Spawn" + zombieNum;
        zombieNum++;
    }
}
