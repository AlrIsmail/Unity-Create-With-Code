using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    float speed = 10;
    Vector3 angle;
    GameObject[] enemies;
    private void Start()
    {
        angle = GameObject.Find("Player").transform.forward.normalized;
        transform.position += angle * speed * Time.deltaTime;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    // Update is called once per frame
    void Update()
    {
        Transform target = FindTarget().transform;
        if ( target != null)
        {
            Vector3 moveDirection = (target.transform.position -
            transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    }
    private GameObject FindTarget()
    {
        int closest = 0;
        int lene = enemies.Length;
        float closestDist = 0;
        if (lene > 1) { 
            float closestDistx = enemies[closest].transform.position.x - transform.position.x;
            float closestDistz = enemies[closest].transform.position.z - transform.position.z;
            closestDist = HypotenuseLength(closestDistx, closestDistz);
        }
        for (int i = 1; i < enemies.Length; i++){
            float Distx = enemies[i].transform.position.x - transform.position.x;
            float Distz = enemies[i].transform.position.z - transform.position.z;
            float Dist = HypotenuseLength(Distx, Distz);
            if (closestDist > Dist)
            {
                closest = i;
                closestDist = Dist;
            }
        }
        return enemies[closest];
    }
    float HypotenuseLength(float sideALength, float sideBLength)
    {
        return Mathf.Sqrt(sideALength * sideALength + sideBLength * sideBLength);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
