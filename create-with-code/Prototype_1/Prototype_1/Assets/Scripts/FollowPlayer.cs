using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    private Vector3 cameraoffset = new Vector3(0, 5, -7);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //This is moved AFTER our camera is moved.
    void LateUpdate()
    {
        /* You can look at where you started putting the camera to put it behind the player
         in a preffered position. */
        transform.position = Player.transform.position + cameraoffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
