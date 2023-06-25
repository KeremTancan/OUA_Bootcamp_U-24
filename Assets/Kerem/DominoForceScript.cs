using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoForceScript : MonoBehaviour
{
    public int pushforce = 3;
    private bool hasCodeExecuted = false;

    void Update()
    {
        if (Movement.isDomino && !hasCodeExecuted)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * pushforce, ForceMode.Impulse);
            hasCodeExecuted = true;
        }
    }
}
