using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Modifier : MonoBehaviour
{
    GameObject[] zombieList;

    public float zombieSpeed;
    public float zombieAngularSpeed;
    public float zombieAcceleration;
    public float attackDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zombieList = GameObject.FindGameObjectWithTag("Deleter").GetComponent<EnemiesDeleter>().enemies;

        foreach (GameObject item in zombieList)
        {
            if(item != null)
            {
                item.GetComponent<AI_Navigation>().speed = zombieSpeed;
                item.GetComponent<AI_Navigation>().angularSpeed = zombieAngularSpeed;
                item.GetComponent<AI_Navigation>().acceleration = zombieAcceleration;
                item.GetComponent<AI_Navigation>().distanceToPlayer = attackDistance;
            }
            else
            {
                return;
            }
            
        }
    }
}
