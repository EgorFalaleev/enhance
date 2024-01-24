using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/GameStatsController", order = 1)]
public class GameStatsController : ScriptableObject
{
    public int Level { get; set; }
    public int EnemiesKilled { get; set; }
}
