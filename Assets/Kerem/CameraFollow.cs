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

    private float timer = 0f;
    private float duration = 5f;
    public static bool isRunning = false;

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
            StartExecution();
        }
        if (isRunning)
        {

            camera1.enabled = false;
            camera2.enabled = true;

            timer += Time.deltaTime;

            if (timer >= duration)
            {
                
                isRunning = false;
                timer = 0f;
            }
        }
    }

    private void StartExecution()
    {
        isRunning = true;
    }

}


