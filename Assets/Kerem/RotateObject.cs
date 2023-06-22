using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f; 
    private bool isPaused = false; 
    private float pauseDuration = 3f; 
    private float pauseTimer = 0f; 

    void Update()
    {
        if (!isPaused)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.right, rotationAmount); 
        }
        else
        {
            
            pauseTimer += Time.deltaTime;

            if (pauseTimer >= pauseDuration)
            {
                
                isPaused = false;
                pauseTimer = 0f;
            }
        }

        
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseRotation();
        }
    }

    void PauseRotation()
    {
        isPaused = true;
    }
}
