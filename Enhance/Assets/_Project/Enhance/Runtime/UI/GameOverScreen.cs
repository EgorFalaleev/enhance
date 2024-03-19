using System;
using Enhance.Runtime.Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enhance.Runtime.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [Header("UI Components")] 
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private TMP_Text _levelNumberText;
        [SerializeField] private TMP_Text _enemiesKilledNumberText;
        [SerializeField] private TMP_Text _highScoreText;

        [Header("References")] 
        [SerializeField] private PlayerHealthHandler _playerHealthHandler;
        [SerializeField] private GameStatsController _gameStatsController;

        private void OnEnable()
        {
            _playerHealthHandler.OnDie += HandlePlayerDeath;
        }

        private void OnDisable()
        {
            _playerHealthHandler.OnDie -= HandlePlayerDeath;
        }

        private void HandlePlayerDeath(object sender, EventArgs e)
        {
            _gameOverScreen.SetActive(true);
            
            SetupGameOverScreen();
        }

        private void SetupGameOverScreen()
        {
            _levelNumberText.text = _gameStatsController.Level.ToString();
            _enemiesKilledNumberText.text = _gameStatsController.EnemiesKilled.ToString();
            _highScoreText.text = _gameStatsController.GetHighScore().ToString();
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
