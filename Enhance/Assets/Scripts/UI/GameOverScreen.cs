using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private TMP_Text _enemiesKilledNumberText;

    public void SetupGameOverScreen(int level, int enemiesKilled)
    {
        gameObject.SetActive(true);

        _levelNumberText.text = level.ToString();
        _enemiesKilledNumberText.text = enemiesKilled.ToString();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
