using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private int speed;
    void Start()
    {
        speed = 6;
    }

    // Update is called once per frame
   
    void Update()
    {

        if (transform.position.x > 4)
        {
            speed = -6;

        }
        else if (transform.position.x < -2)
        {
            speed = 6;
        }
        //transform.Translate(Time.deltaTime * speed, 0, 0);
        
        this.transform.Translate(new Vector3(Time.unscaledDeltaTime * speed, 0, 0));

       
    }
}
