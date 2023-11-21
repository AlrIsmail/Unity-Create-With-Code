using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && time > 1.0f)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            time = 0.0f;
        }
    }
}
