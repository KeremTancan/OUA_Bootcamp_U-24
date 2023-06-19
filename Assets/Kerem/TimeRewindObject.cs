using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewindObjectt : MonoBehaviour
{
    private struct ObjectState
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    private bool isRewinding = false;
    private List<ObjectState> objectStates = new List<ObjectState>();

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isRewinding)
                StartRewind();
            else
                StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
            RewindObject();
        else
            RecordObjectState();
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
            ObjectState state = objectStates[objectStates.Count - 1];
            transform.position = state.position;
            transform.rotation = state.rotation;
            objectStates.RemoveAt(objectStates.Count - 1);
        }
        else
        {
            StopRewind();
        }
    }

    private void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    private void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}

