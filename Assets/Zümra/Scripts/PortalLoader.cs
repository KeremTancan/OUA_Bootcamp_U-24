using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class PortalLoader : MonoBehaviour
{
    public PlayableDirector playDirector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playDirector.Play();
            other.gameObject.SetActive(false); // Oyuncuyu gizleyebilirsiniz, isteðe baðlý.
            playDirector.stopped += OnTimelineFinished;
        }
    }

    private void OnTimelineFinished(PlayableDirector pd)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
