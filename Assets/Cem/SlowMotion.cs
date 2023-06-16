using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowdownLength = 2f;
        

    void Start()
    {
        Time.timeScale = 1; 
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            Time.timeScale = 0.4f;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            //Time.timeScale = 1;

        }
    }
}
