using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false); 
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
