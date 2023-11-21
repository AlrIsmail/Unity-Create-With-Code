using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playerSource;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public bool isTrigger = false;
    public bool doubleSpeed = false;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {   if (!isTrigger)
            {
                playerAnim.SetTrigger("Jump_trig");
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                playerRB.AddForce(Vector3.up * jumpForce/2, ForceMode.Impulse);
                playerAnim.Play("Running_Jump", 3, 0f);
            }
                
            isOnGround = false;
            dirtParticle.Stop();
            playerSource.PlayOneShot(jumpSound, 1.0f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if (doubleSpeed)
        {
            doubleSpeed = false;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            isTrigger = false;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstcale"))
        {
            gameOver = true;
            Debug.Log("Game Over for you !!!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            explosionParticle.Stop();
            explosionParticle.Play();
            dirtParticle.Stop();
            playerSource.PlayOneShot(crashSound, 1.0f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            isTrigger = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstcale"))
        {
            gameOver = true;
            Debug.Log("Game Over for you !!!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            explosionParticle.Stop();
            explosionParticle.Play();
            dirtParticle.Stop();
            playerSource.PlayOneShot(crashSound, 1.0f);
        }
    }
}
