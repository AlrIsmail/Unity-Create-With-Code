using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstecalePrefabs;
    private Vector3 spawnPos = new(25,0,0);
    private float startDelay = 3;
    private float repeatInterval = 2.3f;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        int obstecaleIndex = Random.Range(0, obstecalePrefabs.Length);
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstecalePrefabs[obstecaleIndex], spawnPos, obstecalePrefabs[obstecaleIndex].transform.rotation);
        }
        
    }
}
