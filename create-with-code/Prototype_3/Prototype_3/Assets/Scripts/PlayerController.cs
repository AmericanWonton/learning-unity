using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        /* This is shorthand for Physics.gravity = Physics.gravity * gravityModifier */
        Physics.gravity *= gravityModifier;
        //playerRB.AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
         /* Check if the player is on the ground before letting them jump */
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //Force Mode is a mode of which you add a force...in this case, it's a very quick force, immediatley
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            /* Had an issue, couldn't get this working... */
            isOnGround = false;
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
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game Over!");
        } else
        {
            Debug.Log("FR, I dunno what you're colliding with....");
        }
        
    }
}
