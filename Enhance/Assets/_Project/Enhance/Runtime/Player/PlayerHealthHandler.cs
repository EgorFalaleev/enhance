using System;
using Enhance.Data;
using Enhance.Runtime.UI;
using UnityEngine;

namespace Enhance.Runtime.Player
{
    public class PlayerHealthHandler : MonoBehaviour, IDamageable
    {
        [SerializeField] private PlayerConfigSO _playerConfig;
        [SerializeField] private GameStatsController _gameStatsController;
        // TODO: refactor, view inside logic 
        [SerializeField] private GameOverScreen _gameOverScreen;

        public int CurrentHealth { get; private set; }

        public event EventHandler OnDamageTaken;
        public event EventHandler OnDie;

        private void Start()
        {
            Time.timeScale = 1f;

            _gameStatsController.ResetStats();
            CurrentHealth = _playerConfig.MaxHealth;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // bumping into enemy always deals 1 damage
            if (collision.gameObject.CompareTag(Tags.ENEMY))
            {
                TakeDamage(1);
            }
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            if (OnDamageTaken != null)
                OnDamageTaken(this, EventArgs.Empty);


            if (CurrentHealth <= 0)
            {
                if (OnDie != null)
                    OnDie(this, EventArgs.Empty);
                
                Die();
            }
        }

        public void Die()
        {
            _gameStatsController.Level = GetComponent<Player>()._levelUpSystem.GetLevel();
            _gameStatsController.SetHighScore(_gameStatsController.EnemiesKilled);
            // TODO: need to find something better than that
            _gameOverScreen.SetupGameOverScreen(_gameStatsController.Level, _gameStatsController.EnemiesKilled, _gameStatsController.GetHighScore());
        
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0f;
        }
    }
}
