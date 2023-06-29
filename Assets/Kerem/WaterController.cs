using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        rigidbody.mass = 1.0f;
        // Check if the object has a Rigidbody component
        if (rigidbody != null)
        {
            // Apply buoyancy force to the object
            rigidbody.AddForce(Vector3.up * 5f, ForceMode.Force);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();

        rigidbody.mass = 0.5f;
        rigidbody.velocity= Vector3.zero;
    }
}
