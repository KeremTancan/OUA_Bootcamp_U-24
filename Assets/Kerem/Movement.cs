using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;
    private bool onGround = false;
    public static bool isDomino = false;

    Animator anim;
    public float jumpForce = 2f;

    

    public static bool isMountain;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        GatherInput();
        Look();
    }

    private void FixedUpdate()
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("isJumping", false);
        

        if (_input != Vector3.zero)
        {
            Move();
            anim.SetBool("isRunning", true);
        }

        if(onGround && Input.GetKeyDown(KeyCode.Space))
        {
            
            onGround = false;
            anim.SetTrigger("isJumping");
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("bone"))
        {

            isDomino = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mountain"))
        {
            
            isMountain = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("mountain"))
        {
            
            isMountain = false;
        }
        
    }
    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }


    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
        
    }

    
}
