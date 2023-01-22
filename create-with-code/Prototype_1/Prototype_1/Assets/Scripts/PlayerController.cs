using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame,(50-60 times per second)
    void Update()
    {
        //Moving the vehicle forward
        //transform.Translate(0, 0, 1);
        /* We want to not move our car frame by frame. We want to move the car forward in a time/speed frame
         * Move forward x amoutnt od distance over seconds
         */
        transform.Translate(Vector3.forward * Time.deltaTime * 20);
    }
}
