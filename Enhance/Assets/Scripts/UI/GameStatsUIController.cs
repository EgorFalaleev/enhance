using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatsUIController : MonoBehaviour
{
    [SerializeField] private GameStatsController _gameStats;
    [SerializeField] private TMP_Text _enemiesKilledNumberText;

    private void Update()
    {
        _enemiesKilledNumberText.text = _gameStats.EnemiesKilled.ToString();
    }
}
