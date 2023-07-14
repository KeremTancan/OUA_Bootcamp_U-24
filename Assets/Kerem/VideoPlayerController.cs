using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController : MonoBehaviour
{
    public GameObject videoPlayer;
  

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            videoPlayer.SetActive(true);
        }
    }

    private void OnVideoEnd(VideoPlayer player)
    {
        // Unsubscribe from the event to prevent multiple scene changes
        player.loopPointReached -= OnVideoEnd;

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
