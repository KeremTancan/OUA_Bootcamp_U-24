using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public string MainMenu; // Geçmek istediðiniz bir sonraki sahnenin adý

    public void OnSkipButtonClick()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
