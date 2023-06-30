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
        ObjectState state = new ObjectState();
        state.position = transform.position;
        state.rotation = transform.rotation;
        objectStates.Add(state);
        
    }

    private void RewindObject()
    {
        if (objectStates.Count > 0)
        {
            GeriSar = true;

            ObjectState state = objectStates[objectStates.Count - 1];
            transform.position = state.position;
            transform.rotation = state.rotation;
            objectStates.RemoveAt(objectStates.Count - 1);        
        }
        
        else
        {
            StopRewind();
            GeriSar = false;
        }
    }

    private void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
        CameraFollow.isRunning = true;
    }

    private void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = true;
        CameraFollow.isRunning = false;
        
    }
}

