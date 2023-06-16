using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnimations : MonoBehaviour
{
    private bool paused = false;
    private float pauseDuration = 5f;
    private int stopCounter = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StopAnimations();
        }
    }

    void StopAnimations()
    {
        if (stopCounter < 2)
        {
            paused = true;
            StartCoroutine(StartAnimations());
            stopCounter++;
        }
        
    }

    IEnumerator StartAnimations()
    {
        // Durma süresi boyunca animasyonları durdur
        foreach (var obje in GameObject.FindGameObjectsWithTag("stop"))
        {
            var animator = obje.GetComponent<Animator>();
            if (animator != null)
            {
                animator.speed = 0f;
            }
        }

        // Belirtilen süre kadar bekleyip sonra animasyonları tekrar başlat
        yield return new WaitForSeconds(pauseDuration);

        foreach (var obje in GameObject.FindGameObjectsWithTag("stop"))
        {
            var animator = obje.GetComponent<Animator>();
            if (animator != null)
            {
                animator.speed = 1f;
            }
        }

        paused = false;
    }
}
