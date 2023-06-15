using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;

    private bool canMove = true;

    CharacterController ch;
    void Start()
    {
        ch = GetComponent<CharacterController>();
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            float x = Input.GetAxis("Horizontal") * moveSpeed * Time.unscaledDeltaTime;
            float z = Input.GetAxis("Vertical") * moveSpeed * Time.unscaledDeltaTime;
            ch.Move(new Vector3(x, 0, z));
        }
       
    }
}
