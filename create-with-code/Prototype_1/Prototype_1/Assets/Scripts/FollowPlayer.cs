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

    // Update is called once per frame
    void Update()
    {
        /* You can look at where you started putting the camera to put it behind the player
         in a preffered position. */
        transform.position = Player.transform.position + cameraoffset;
    }
}
