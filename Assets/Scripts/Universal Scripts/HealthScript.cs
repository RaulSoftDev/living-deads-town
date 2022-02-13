using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour {

    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private CustomMovement playerMO;
    private Pattack playerAT;

    private bool characterDied;

    public bool is_Player;
    public bool is_NPC;

    private HealthUI health_UI;
    GameObject[] enemyNM;
    Animator playerAN;

    GameObject canvas;
    GameObject deathMenu;

    public GameObject healthSpawn;
    public GameObject death;
    public GameObject joystick;

    void Awake() {
        animationScript = GetComponentInChildren<CharacterAnimation>();

        if(is_Player) {
            health_UI = GetComponent<HealthUI>();
        }

        if (is_NPC)
        {
            health_UI = GetComponent<HealthUI>();
        }
    }

    IEnumerator CheckEnemies()
    {
        yield return new WaitForSecondsRealtime(8f);
        enemyNM = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Start()
    {
        StartCoroutine(CheckEnemies());
        playerAN = GetComponent<Animator>();
        playerMO = GetComponent<CustomMovement>();
        playerAT = GetComponent<Pattack>();
        canvas = GameObject.FindGameObjectWithTag("DeathMenu");
        
    }

    public void ApplyDamage(float damage, bool knockDown) {

        if (characterDied)
            return;

        health -= damage;

        // display health UI
        if(is_Player) {
            health_UI.DisplayHealth(health);
        }

        if (is_NPC)
        {
            health_UI.DisplayNPCHealth(health);
        }

        if (health <= 0f) {
            characterDied = true;

            // if is player deactivate enemy script
            if(is_Player)
            {
                playerAT.enabled = false;
                playerMO.enabled = false;
                playerAN.SetTrigger("Death");

                StartCoroutine(DeathScene());
               
            }

            if (is_NPC)
            {
                GameObject objectClone;

                if (Random.value <= 0.3)
                {
                    objectClone = Instantiate(healthSpawn, new Vector3(transform.position.x, 1, transform.position.z), healthSpawn.transform.rotation);
                }
            }

            return;
        }

        



    } // apply damage

    IEnumerator DeathScene()
    {
        yield return new WaitForSeconds(1.25f);
        joystick.SetActive(false);
        death.SetActive(true);
        Time.timeScale = 0;
        yield break;
    }



} // class




































