using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rollingSpeed = 10f;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * rollingSpeed;
    }
}
