using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpMessage1 : MonoBehaviour
{
    public GameObject text;
    //public string LevelName;
    public GameObject portal;
    public GameObject missingart;
    private bool isTextActive = false;

    private void Start()
    {
        text.SetActive(false);
        portal.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);      
            isTextActive= true;
        }        
    }

    private void FixedUpdate()
    {
        if(isTextActive && Input.GetKeyDown(KeyCode.F))
        {
            portal.SetActive(true);
            missingart.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}
