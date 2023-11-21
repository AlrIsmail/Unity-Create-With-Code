using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 15.0f;
    public float zRangeUp = 4.5f;
    public float zRangeDown = -1.0f;
    public GameObject progetilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }else if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < zRangeDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeDown);
        }
        else if (transform.position.z > zRangeUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeUp);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(progetilePrefab, transform.position + new Vector3(0, 0, 1), progetilePrefab.transform.rotation);
        }
    }
}
