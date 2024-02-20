using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enhance.Runtime.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelNumberText;
        [SerializeField] private TMP_Text _enemiesKilledNumberText;
        [SerializeField] private TMP_Text _highScoreText;

        public void SetupGameOverScreen(int level, int enemiesKilled, int highScore)
        {
            gameObject.SetActive(true);

            _levelNumberText.text = level.ToString();
            _enemiesKilledNumberText.text = enemiesKilled.ToString();
            _highScoreText.text = highScore.ToString();
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
}
