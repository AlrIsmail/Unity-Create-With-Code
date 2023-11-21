using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 100.0f;
    Rigidbody enemyRB;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDir * speed * Time.deltaTime);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
