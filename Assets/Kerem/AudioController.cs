using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void LateUpdate()
    {
        if(TimeRewindObjectt.GeriSar)
        {         
            audioSource.pitch = -1f;
            Debug.Log("-1");
        }
        
        if (RotateObject.Durdu || ObjectSpawner.Durdu)
        {
            Debug.Log("0.5");
            audioSource.pitch = 0.5f;  
        }

        else if (!TimeRewindObjectt.GeriSar)
        {
            Debug.Log("1");
            audioSource.pitch = 1f;
        }
        
    }
   
}
