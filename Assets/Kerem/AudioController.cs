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
        }
        
        if (RotateObject.Durdu)
        {
            audioSource.pitch = 0.5f;  
        }

        else if (!TimeRewindObjectt.GeriSar)
        {
            audioSource.pitch = 1f;
        }
        
    }
   
}
