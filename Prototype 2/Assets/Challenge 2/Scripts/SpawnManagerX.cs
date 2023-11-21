using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;
    private float time = 0.0f;

    // Spawn random ball at random x position at top of play area
    private void Start()
    {
        SpawnRandomBall();
    }
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time > 3.0f)
        {
            Invoke("SpawnRandomBall", Random.Range(0, 3));
            time = 0.0f;
        }
        
    }
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[0].transform.rotation);
    }

}
