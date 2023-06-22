using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowdownLength = 8f;
        

    void Start()
    {
        Time.timeScale = 1; 
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            Time.timeScale = 0.2f;
        }
        else
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            
        }
        
        
    }
}
