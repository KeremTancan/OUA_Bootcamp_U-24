using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class RespawnController : MonoBehaviour
{
    private Vector3 previousPosition;
    private List<Vector3> positionHistory;

   
    void Start()
    {
        positionHistory = new List<Vector3>();
        previousPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (transform.position.y <= 13)
        {
            MoveToPreviousPosition();
        }
        else 
        {
            positionHistory.Add(transform.position);
           
        }
    }

    void MoveToPreviousPosition()
    {
        transform.position = positionHistory[positionHistory.Count - 100];

        positionHistory.Clear();
    }

    
}

