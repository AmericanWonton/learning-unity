using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBoundry = 30.0f;
    private float lowerBoundry = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBoundry)
        {
            //This will destroy the current object this script is applied to
            Destroy(gameObject);
        } else if (transform.position.z < lowerBoundry)
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }
}
