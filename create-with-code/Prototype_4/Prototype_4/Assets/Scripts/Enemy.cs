using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = ((player.transform.position - transform.position).normalized);
        //The .normalize will 'normalize' the length of this vector...this makes 
        //The ball chase the player at normal speeds, no matter the distance
        enemyRb.AddForce(lookDirection * speed);
    }
}
