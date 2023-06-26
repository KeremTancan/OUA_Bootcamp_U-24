using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    private float shakeIntensity = 0.1f;
    private Vector3 originalPosition;
   
    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (CameraFollow.isRunning)
        {
            float offsetX = Random.Range(-1f, 1f) * shakeIntensity;
            float offsetY = Random.Range(-1f, 1f) * shakeIntensity;
            
            transform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0f);
      
        }
    }

   
}
