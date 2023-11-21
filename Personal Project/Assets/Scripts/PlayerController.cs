using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Gravity")]
    [SerializeField] float gravity = 0.01f;
    [SerializeField] float gravityMultiplier = 0.01f;
    [SerializeField] float groundedGravity = -0.01f;
    [SerializeField] float jumpHeight = 0f;
    [SerializeField] float rotationSmoothTime;
    [SerializeField] GameObject flame;
    float velocityY;
    float currentAngle;
    float currentAngleVelocity;
    float speed = 5;
    bool usingFlame = false;
    GameObject tempFlame;
    CharacterController controller;
    Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleGravityAndJump();
        ConstrainPlayerPositionTemp();
        HandaleFlameThrow();
    }
    private void HandleMovement()
    {
        //capturing Input from Player
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized; 
        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0, currentAngle, 0); Vector3 rotatedMovement = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(rotatedMovement * speed * Time.deltaTime);
        }

    }
    void HandleGravityAndJump()
    {
        if (controller.isGrounded && velocityY < 0f) { 
            velocityY = groundedGravity;
        }
        if ((velocityY < -20 || controller.isGrounded) && Input.GetKeyDown(KeyCode.Space))
        {
            velocityY = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }
        velocityY -= gravity * gravityMultiplier * Time.deltaTime;
        controller.Move(Vector3.up * velocityY * Time.deltaTime);
    }
    void ConstrainPlayerPositionTemp()
    {
        Vector3 playerPos = transform.position;
        if (playerPos.x > 20)
        {
            transform.position = new(20, playerPos.y, playerPos.z);
        }else if (playerPos.x < -20)
        {
            transform.position = new(-20, playerPos.y, playerPos.z);
        }
        if (playerPos.z > 20)
        {
            transform.position = new(playerPos.x, playerPos.y, 20);
        }
        else if (playerPos.z < -20)
        {
            transform.position = new(playerPos.x, playerPos.y, -20);
        }
    }
    void HandaleFlameThrow()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && !usingFlame)
        {
            tempFlame = Instantiate(flame, transform.position - (transform.right/2), transform.rotation);
            StartCoroutine(ThrowFlame());
        }
    }
    IEnumerator ThrowFlame()
    {
        usingFlame = true;
        yield return new WaitForSeconds(2);
        Destroy(tempFlame);
        usingFlame = false;

    }

}
