using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;
    public EnemyMovement[] spawnedEnemies;
    public List<GameObject> zombiesPrefabs = new List<GameObject>();

    private GameObject enemyClone;
    [SerializeField]private int EnemyNumber = 3;
    private int EnemyNumerator = 0;

    public bool move;
    public bool disabled;
    private Vector3 scale;
    public Vector3 spawnPoint;

    float MaxXPosition;
    float MinXPosition;
    float MaxZPosition;
    float MinZPosition;

    public float finalXPosition;
    public float finalZPosition;

    GameObject[] enemies;


    void Awake() {

        if (instance == null)
            instance = this;

        SpawnPosition();
    }

    void SpawnPosition()
    {
        if(GameObject.Find("EventManager") != null)
        {
            if (GameObject.Find("EventManager").GetComponent<EventManager>().scene1Active)
            {
                MaxXPosition = 604.6f;
                MinXPosition = 435.6f;
                finalXPosition = Random.Range(MinXPosition, MaxXPosition);

                MaxZPosition = 203.4f;
                if (finalXPosition > 523.3f)
                {
                    MinZPosition = 90f;
                }
                else
                {
                    MinZPosition = 138.8f;
                }
                finalZPosition = Random.Range(MinZPosition, MaxZPosition);
            }
            else
            {
                return;
            }

            if (GameObject.Find("EventManager").GetComponent<EventManager>().scene2Active)
            {
                MaxXPosition = 405.3f;
                MinXPosition = 300f;
                finalXPosition = Random.Range(MinXPosition, MaxXPosition);

                MaxZPosition = 203.4f;
                if (finalXPosition > 338.3f)
                {
                    MinZPosition = 121f;
                }
                else
                {
                    MinZPosition = 168.4f;
                }
                finalZPosition = Random.Range(MinZPosition, MaxZPosition);
            }
            else
            {
                return;
            }

            if (GameObject.Find("EventManager").GetComponent<EventManager>().scene3Active)
            {
                MaxXPosition = 353.9f;
                MinXPosition = 253.4f;
                finalXPosition = Random.Range(MinXPosition, MaxXPosition);

                MaxZPosition = 492f;
                MinZPosition = 309.4f;
                finalZPosition = Random.Range(MinZPosition, MaxZPosition);
            }
            else
            {
                return;
            }

            if (GameObject.Find("EventManager").GetComponent<EventManager>().scene4Active)
            {
                MaxXPosition = 495.6f;
                MinXPosition = 377.7f;
                finalXPosition = Random.Range(MinXPosition, MaxXPosition);

                MaxZPosition = 490.75f;
                MinZPosition = 301.6f;
                finalZPosition = Random.Range(MinZPosition, MaxZPosition);
            }
            else
            {
                return;
            }

            if (GameObject.Find("EventManager").GetComponent<EventManager>().scene5Active)
            {
                MaxXPosition = 531f;
                MinXPosition = 304.7f;
                finalXPosition = Random.Range(MinXPosition, MaxXPosition);

                MaxZPosition = 704.9f;
                MinZPosition = 610.64f;
                finalZPosition = Random.Range(MinZPosition, MaxZPosition);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
        

    }

    void Start() {
        SpawnEnemy();

        scale = GameObject.FindGameObjectWithTag("Player").transform.localScale;


        spawnPoint = new Vector3(finalXPosition, 0, finalZPosition);
    }
    
    void Update()
    {
        spawnedEnemies = FindObjectsOfType<EnemyMovement>();

        if (spawnedEnemies.Length > 0)
        {
            StartCoroutine(EnemyBegins());
        }

        if(spawnedEnemies.Length == EnemyNumber)
        {
            StopAllCoroutines();
        }

        if(enemyClone != null)
        {
            enemyClone.transform.localScale = scale;
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            enemy.transform.parent.transform.SetParent(GameObject.FindGameObjectWithTag("EnemyFolder").transform);
        }
        
    }

    IEnumerator EnemyBegins()
    {

        yield return new WaitForSecondsRealtime(1.5f);

        if (spawnedEnemies.Length == 0)
        {
            SpawnEnemy();
            move = false;
        }

        yield return null;
    }

    public void SpawnEnemy()
    {
        StartCoroutine("EnemyWait");
    }

    IEnumerator EnemyWait()
    {

        for (int i = 0; i < EnemyNumber; i++)
        {
            yield return new WaitForSeconds(2);
            enemyClone = Instantiate(zombiesPrefabs[Random.Range(0,zombiesPrefabs.Count)], new Vector3(spawnPoint.x + Random.Range(0,5), spawnPoint.y, spawnPoint.z + Random.Range(0, 5)), Quaternion.identity);
            enemyClone.name = "enemy" + EnemyNumerator;
            EnemyNumerator++;
        }
    }

    private void OnEnable()
    {
        if (disabled)
        {
            Awake();
            Start();
            disabled = false;
        }
        
    }

    private void OnDisable()
    {
        disabled = true;
    }

    private void FixedUpdate()
    {
        transform.position = spawnPoint;
    }
}
