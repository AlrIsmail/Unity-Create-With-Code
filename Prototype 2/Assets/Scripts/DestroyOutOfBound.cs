using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    // Start is called before the first frame update
    private float topBound = 30.0f;
    private float botBound = -10.0f;
    private float sideBound = 22.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < botBound)
        {
            Destroy(gameObject);
            ScoreManager.looseLive();
        }
        else if (transform.position.x > sideBound)
        {
            Destroy(gameObject);
            ScoreManager.looseLive();
        }
        else if (transform.position.x < -sideBound)
        {
            ScoreManager.looseLive();
        }
    }
}
