using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsScreenManager : MonoBehaviour
{
    GameObject playerGameObject;
    GameObject[] enemiesGameObjects;

    HealthScript playerCurrentHealth;
    HealthUI playerMaxHealth;

    Pattack attackScript;
    CustomMovement playerMoveScript;

    bool InvencibleActive;
    public bool controlInverted;

    private void Awake()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");

        playerCurrentHealth = playerGameObject.GetComponent<HealthScript>();
        playerMaxHealth = playerGameObject.GetComponent<HealthUI>();

        attackScript = playerGameObject.GetComponent<Pattack>();

        playerMoveScript = playerGameObject.GetComponent<CustomMovement>();
    }

    private void Start()
    {
        /*IncreasePlayerHealth();
        IncreasePlayerDamage();
        IncreasePlayerSpeed();*/
    }

    private void Update()
    {
        enemiesGameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        /*IncreaseEnemiesHealth();
        IncreaseEnemiesDamage();
        IncreaseEnemiesSpeed();
        IncreaseEnemiesStunTime();*/

        if (controlInverted)
        {
            StartCoroutine(IsControlsInverted());
        }
        
    }

    void IncreasePlayerHealth()
    {
        playerMaxHealth.maxHealth = 200f;
        playerCurrentHealth.health = 200f;
    }

    void IncreasePlayerDamage()
    {
        attackScript.increasedDamage += 20;
    }

    void IncreasePlayerSpeed()
    {
        playerMoveScript.moveSpeed += 5;
    }

    void IncreaseEnemiesHealth()
    {
        foreach (GameObject enemy in enemiesGameObjects)
        {
            enemy.GetComponent<HealthScript>().health = 200f;
            enemy.GetComponent<HealthUI>().maxNPCHealth = 200f;
        }
    }

    void IncreaseEnemiesDamage()
    {
        foreach (GameObject enemy in enemiesGameObjects)
        {
            enemy.GetComponent<AI_Navigation>().attackDamage = 10;
        }
    }

    void IncreaseEnemiesSpeed()
    {
        foreach (GameObject enemy in enemiesGameObjects)
        {
            enemy.GetComponent<AI_Navigation>().speed = 10;
            enemy.GetComponent<AI_Navigation>().angularSpeed = 650;
            enemy.GetComponent<AI_Navigation>().acceleration = 11;
        }
    }

    void IncreaseEnemiesStunTime()
    {
        foreach (GameObject enemy in enemiesGameObjects)
        {
            enemy.GetComponent<AI_Navigation>().stunTime = 15.0f;
        }
    }

    void EnableInstaKill()
    {
        StartCoroutine(InstaKill());
    }

    IEnumerator InstaKill()
    {
        attackScript.playerAttackDamage = 1000;
        yield return new WaitForSecondsRealtime(15f);
        attackScript.playerAttackDamage = 20.0f;
    }

    void Invencible()
    {
        if (InvencibleActive)
        {
            StartCoroutine(InvencibilityTime());
            InvencibleActive = !InvencibleActive;
        }
    }

    IEnumerator InvencibilityTime()
    {
        float currentHealth = playerCurrentHealth.health;
        playerCurrentHealth.health = 1000f;
        yield return new WaitForSecondsRealtime(10f);
        playerCurrentHealth.health = currentHealth;
    }

    void ZombiesAwareOfPlayerEveryWhere()
    {
        foreach (GameObject enemy in enemiesGameObjects)
        {
            enemy.GetComponent<AI_Navigation>().onPanic = true;
        }
    }

    void ZombiesNotAwareOfPlayer()
    {
        StartCoroutine(EnemiesNotPanic());
    }

    IEnumerator EnemiesNotPanic()
    {
        foreach (GameObject enemy in enemiesGameObjects)
        {
            enemy.GetComponent<AI_Navigation>().onPanic = false;
        }

        yield return new WaitForSecondsRealtime(35f);

        StopCoroutine(EnemiesNotPanic());
    }

    void InvertedControls()
    {
        controlInverted = true;
    }

    IEnumerator IsControlsInverted()
    {
        playerGameObject.GetComponent<CustomMovement>().isInverted = true;
        yield return new WaitForSecondsRealtime(10f);
        playerGameObject.GetComponent<CustomMovement>().isInverted = false;
        controlInverted = false;
    }
}
