using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public int pointValue;
    private Game_Manager game_Manager;
    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -6f;
    private Rigidbody targetrb;
    // Start is called before the first frame update
    void Start()
    {
        game_Manager = GameObject.Find("Game Manager").GetComponent<Game_Manager>();
        targetrb = GetComponent<Rigidbody>();
        targetrb.AddForce(RandomForce(), ForceMode.Impulse);
        /* This is used for the object rotation as they are flung */
        targetrb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Used to give a random, upward force*/
    Vector3 RandomForce() 
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    /* Used to give objects a random spin */
    float RandomTorque() 
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    /* Random Spawn Position */
    Vector3 RandomSpawnPos() 
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    /* Destroy obejct on mouse down */
    private void OnMouseDown() 
    {
        Destroy(gameObject);
        game_Manager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position,explosionParticle.transform.rotation);
    }

    /* Destroys object when it leaves the scene. These will get caught by the Sensor below the scene */
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    /* These two functions happen so often in Unity, these are already methods.
    They get called when you click on something */
    private void OnMouseUp()
    {

    }
}
