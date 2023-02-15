using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    private Animator playerAnim;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        /* This is shorthand for Physics.gravity = Physics.gravity * gravityModifier */
        Physics.gravity *= gravityModifier;
        //playerRB.AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
         /* Check if the player is on the ground before letting them jump */
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver != true)
        {
            //Force Mode is a mode of which you add a force...in this case, it's a very quick force, immediatley
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            /* Had an issue, couldn't get this working... */
            isOnGround = false;
            /* Used for jump animation */
            playerAnim.SetTrigger("Jump_trig");
            /* Used to stop the dirt particle when jumping */
            dirtParticle.Stop();
            /* Play the Audio when player collides with something */
            playerAudio.PlayOneShot(jumpSound, 800.0f);
            playerAudio.Play();
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Force Mode is a mode of which you add a force...in this case, it's a very quick force, immediatley
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("DEBUG: Character has collided with somethign...");
            isOnGround = true;
            /* Plays the dirt particle if on the ground */
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game Over!");
            /* Stops the dirt particle effect from playing */
            dirtParticle.Stop();
            /* Trigger the death animation if the game is over... */
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            /* Trigger the particle effect for death */
            explosionParticle.Play();
            /* Play the crash sound when colliding */
            Debug.Log("Can you hear us playing a crash?");
            playerAudio.PlayOneShot(crashSound, 10.0f);
        } else
        {
            Debug.Log("FR, I dunno what you're colliding with....");
        }
        
    }
}
