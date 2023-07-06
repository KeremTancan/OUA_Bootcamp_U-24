using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TimeRewindObjectt : MonoBehaviour
{
    private struct ObjectState
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    private bool isRewinding = false;
    public static bool GeriSar;
    private List<ObjectState> objectStates = new List<ObjectState>();
    private Vector3 lastPosition;
    private Quaternion lastRotation;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && rb.isKinematic == false)
        {
            if (!isRewinding)
            {
                StartRewind();
            }
               
            else
            {
                StopRewind();
            }
                
        }
    
        
        if (Movement.isMountain) 
        {    
            rb.isKinematic = false;
        }
    }
    
    private void FixedUpdate()
    {
        if (isRewinding)
        {
            
            RewindObject();
            
        }
            
        else
        {
            RecordObjectState();
        }
            
    }

    private void RecordObjectState()
    {
        if (transform.position != lastPosition || transform.rotation != lastRotation)
        {
            ObjectState state = new ObjectState();
            state.position = transform.position;
            state.rotation = transform.rotation;
            objectStates.Add(state);

            lastPosition = transform.position;
            lastRotation = transform.rotation;

            Debug.Log("Kaydediliyor");
            
        }
    }

    private void RewindObject()
    {
        if (objectStates.Count > 0 )
        {
            ObjectState state = objectStates[objectStates.Count - 1];
            transform.position = state.position;
            transform.rotation = state.rotation;
            objectStates.RemoveAt(objectStates.Count - 1);
            Debug.Log("Gerisarýyor");
            GeriSar = true;
            CameraFollow.isRunning = true;
        }
        
        else
        {
            CameraFollow.isRunning = false;
            Debug.Log("durdu");
            StopRewind();          
        }
    }

    private void StartRewind()
    {
        Debug.Log("baþladý");
        isRewinding = true;
        rb.isKinematic = true;        
        GeriSar = true;
    }

    private void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = true;  
        GeriSar = false;

    }
}

