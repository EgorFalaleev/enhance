using UnityEngine;

namespace Enhance.Runtime
{
    [CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/GameStatsController", order = 1)]
    public class GameStatsController : ScriptableObject
    {
        public int Level => _levelUpSystem.Level;
        public int EnemiesKilled { get; set; }

        private LevelUpSystem _levelUpSystem;
        
        public void ResetStats()
        {
            EnemiesKilled = 0;
        }

        public void SetupLevelUpSystem(LevelUpSystem levelUpSystem)
        {
            _levelUpSystem = levelUpSystem;
        }

        public void SetHighScore(int value)
        {
            if (value > GetHighScore())
                PlayerPrefs.SetInt("HighScore", value);
        }

        public int GetHighScore()
        {
            return PlayerPrefs.GetInt("HighScore", 0); 
        }
    }
}
