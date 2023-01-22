using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(6f, 1.75f, 2f);

    // Start is called before the first frame update
    void Start()
    {

    }

    private void LateUpdate()
    {
        /* You can look at where you started putting the camera to put it behind the player
         in a preffered position. */
        transform.position = plane.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = plane.transform.position + offset;
    }
}
