using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 25;
    private float spawnRangeZ = 15;
    private float spawnPosX = 21;
    private int spawnDelay = 2;
    private float spawnIntgral = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnIntgral);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomAnimal()
    {
        // Randomly generate animal index and spawn position
        int spawnDir = Random.Range(0, 3);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        if (spawnDir == 0)
        { 
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0,180,0));
        }
        else if (spawnDir == 1)
        {
            Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(3, spawnRangeZ));
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, -90, 0));
        }
        else
        {
            Vector3 spawnPos = new Vector3(-spawnPosX, 0, Random.Range(3, spawnRangeZ));
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0));
        }
    }
}
