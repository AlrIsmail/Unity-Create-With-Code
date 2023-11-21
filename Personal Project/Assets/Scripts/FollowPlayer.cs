using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (touchingPlayer()) { 
            Vector3 movement = player.transform.position - transform.position;
            transform.position += movement.normalized * speed * Time.deltaTime;
            ConstrainEnemyPositionTemp();
        }
    }
    void ConstrainEnemyPositionTemp()
    {
        Vector3 enemyPos = transform.position;
        if (enemyPos.x > 20)
        {
            transform.position = new(20, enemyPos.y, enemyPos.z);
        }
        else if (enemyPos.x < -20)
        {
            transform.position = new(-20, enemyPos.y, enemyPos.z);
        }
        if (enemyPos.z > 20)
        {
            transform.position = new(enemyPos.x, enemyPos.y, 20);
        }
        else if (enemyPos.z < -20)
        {
            transform.position = new(enemyPos.x, enemyPos.y, -20);
        }
    }
    private bool touchingPlayer()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 1 && Mathf.Abs(transform.position.z - player.transform.position.z) < 1)
            return false;
        else
            return true;
    }

}
