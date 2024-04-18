using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //target of the camera
    public Transform target;
    //position of the camera compared to the player
    private Vector3 offset;

    // Start is called before the first frame update
    void Awake()
    {
        //position of camera - positoin of the player
        offset = transform.position- target.position;
    }

   //mainly used for camera
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
