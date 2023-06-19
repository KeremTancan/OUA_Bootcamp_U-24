using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset; 

    public float smoothSpeed = 0.5f; 

    private Vector3 desiredPosition; 

    void LateUpdate()
    {
       
        desiredPosition = target.position + offset;

        
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}

