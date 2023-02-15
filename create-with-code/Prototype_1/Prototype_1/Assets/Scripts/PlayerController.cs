using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* You can make these all public if you're debugging...but mostly, you keep them private */
    private float speed = 5.0f;
    public float turnSpeed = 25.0f;
    public float horizontalInput;
    public float forwardInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame,(50-60 times per second)
    void Update()
    {
        //This is for driving left or right.This can be found in the Project Manager, under Input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Moving the vehicle forward
        //transform.Translate(0, 0, 1);
        /* We want to not move our car frame by frame. We want to move the car forward in a time/speed frame
         * Move forward x amoutnt od distance over seconds
         */
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
