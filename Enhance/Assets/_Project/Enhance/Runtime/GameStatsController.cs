using System;
using Enhance.Runtime.Player;
using UnityEngine;

namespace Enhance.Runtime
{
    public class GameStatsController : MonoBehaviour
    {
        public static GameStatsController Instance { get; private set; }
        
        public int Level => _levelUpSystem.Level;
        public int EnemiesKilled { get; set; }

        private LevelUpSystem _levelUpSystem;
        private PlayerHealthHandler _playerHealthHandler;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        private void Start()
        {
            _playerHealthHandler = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerHealthHandler>();
            _playerHealthHandler.OnDie += HandlePlayerDeath;
            
            ResetStats();
        }
        
        public void SetupLevelUpSystem(LevelUpSystem levelUpSystem)
        {
            _levelUpSystem = levelUpSystem;
        }

        public int GetHighScore()
        {
            return PlayerPrefs.GetInt("HighScore", 0); 
        }
        
        private void HandlePlayerDeath(object sender, EventArgs e)
        {
            SetHighScore(EnemiesKilled);
        }
        
        private void ResetStats()
        {
            EnemiesKilled = 0;
        }
        
        private void SetHighScore(int value)
        {
            if (value > GetHighScore())
                PlayerPrefs.SetInt("HighScore", value);
        }
    }
}
