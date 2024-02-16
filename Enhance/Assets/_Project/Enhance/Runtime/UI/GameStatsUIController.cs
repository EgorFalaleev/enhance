using TMPro;
using UnityEngine;

namespace Enhance.Runtime.UI
{
    public class GameStatsUIController : MonoBehaviour
    {
        [SerializeField] private GameStatsController _gameStats;
        [SerializeField] private TMP_Text _enemiesKilledNumberText;

        private void Update()
        {
            _enemiesKilledNumberText.text = _gameStats.EnemiesKilled.ToString();
        }
    }
}
