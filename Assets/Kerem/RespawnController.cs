using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class RespawnController : MonoBehaviour
{
    private Vector3 previousPosition;
    private List<Vector3> positionHistory;

    private float time = 0.0f;
    public float interpolationPeriod = 3f;

    void Start()
    {
        positionHistory = new List<Vector3>();
        previousPosition = transform.position;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (transform.position.y <= 13)
        {
            MoveToPreviousPosition();
        }
        else if (time >= interpolationPeriod)
        {
            positionHistory.Add(transform.position);
            time = 0.0f;
            Debug.Log(positionHistory.Count);
        }
    }

    void MoveToPreviousPosition()
    {
        transform.position = positionHistory[positionHistory.Count - 7];
       

    }

    
}

