using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    public GameObject SpawnManagerPrefab;
    GameObject spawnClone;

    GameObject[] generatedSpawns;

    float spawnNum;
    public float maxSpawns;

    private void Awake()
    {
        spawnNum = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnInstantiate();
    }

    // Update is called once per frame
    void Update()
    {
        generatedSpawns = GameObject.FindGameObjectsWithTag("EnemySpawn");

        foreach (GameObject spawn in generatedSpawns)
        {
            spawn.transform.SetParent(transform);
        }
    }

    void SpawnInstantiate()
    {
        for (int i = 0; i < maxSpawns; i++)
        {
            spawnClone = Instantiate(SpawnManagerPrefab, transform.position, Quaternion.identity);
            spawnClone.name = "Spawn" + spawnNum;
            spawnNum++;
        }
    }
}
