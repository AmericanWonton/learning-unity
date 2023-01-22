using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    private float rotationSpeed = 700.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
