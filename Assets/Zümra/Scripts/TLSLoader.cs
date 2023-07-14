using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TLSLoader : MonoBehaviour
{
    public VideoClip vClip;
    private VideoPlayer vPlayer;

    private void Start()
    {
        vPlayer = gameObject.AddComponent<VideoPlayer>();
        vPlayer.clip = vClip;
        vPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            vPlayer.Play();
            other.gameObject.SetActive(false); // Oyuncuyu gizleyebilirsiniz, isteðe baðlý.
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("StoneAge");
    }
}
