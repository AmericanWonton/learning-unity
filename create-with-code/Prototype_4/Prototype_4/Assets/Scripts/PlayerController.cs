using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float powerupStrength = 15.0f;
    public bool hasPowerup;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5.0f;
    public GameObject powerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal_Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f,0);
    }

    /* Method for trigger events. This is mostly for debugging, not for Pyshics */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            /* This shows our object around powerup */
            powerupIndicator.gameObject.SetActive(true);
            //Starts coroutine that destroys powerup
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    /* Method for collision entering. This is for physics simulation */
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            /* This is used to get the enemy's current position and collision to send it an 
            EXTRA force AWAY from the player when the player collides with it.
            Impulse has this force applied immediatley */
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position); 
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }

    /* An IEnumerator is a special CSharp type. This function will be called, 
    wait for 7 seconds, then do something */
    IEnumerator PowerupCountdownRoutine() 
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        /* This makes our indicator turn off */
        powerupIndicator.gameObject.SetActive(false);
    }
}
