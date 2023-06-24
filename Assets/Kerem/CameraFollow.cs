using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset; 
    public float smoothSpeed = 0.5f; 
    private Vector3 desiredPosition;

    public Camera camera1;
    public Camera camera2;

    void LateUpdate()
    {
        if (!Movement.isMountain)
        {
            camera1.enabled = true;
            camera2.enabled = false;
            

            desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            
            
        }
        else
        {

            camera1.enabled = false;
            camera2.enabled = true;
        }


    }
}

