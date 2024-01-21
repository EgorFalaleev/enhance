using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private float _timeTillNextWave = 10f;
    [SerializeField] private float _timeTillSingleEnemy = 3f;

    private float _waveTimer = 0f;
    private float _singleEnemyTimer = 0f;
    private int _numberOfEnemiesToSpawnNextWave = 10;

    protected override void Update()
    {
        base.Update();

        _waveTimer += Time.deltaTime;
        _singleEnemyTimer += Time.deltaTime;

        if ( _waveTimer > _timeTillNextWave )
        {
            _waveTimer = 0f;

            SpawnMultipleObjects(_numberOfEnemiesToSpawnNextWave);
        }

        if (_singleEnemyTimer > _timeTillSingleEnemy)
        {
            _singleEnemyTimer = 0f;
            SpawnRandomObject();
        }
    }
}
