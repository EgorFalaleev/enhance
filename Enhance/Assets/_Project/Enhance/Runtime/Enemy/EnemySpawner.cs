using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Enemy
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private WavesSpawnerConfigSO _wavesSpawnerConfig;

        private float _waveTimer = 0f;
        private float _singleEnemyTimer = 0f;
        private int _numberOfEnemiesToSpawnNextWave = 3;

        protected override void Update()
        {
            base.Update();

            _waveTimer += Time.deltaTime;
            _singleEnemyTimer += Time.deltaTime;

            if (_waveTimer > _wavesSpawnerConfig.TimeTillNextWave)
            {
                _waveTimer = 0f;

                SpawnMultipleObjects(CalculateNextWaveAmount());
            }

            if (_singleEnemyTimer > _spawnerConfig.TimeTillNextObjectSpawn)
            {
                _singleEnemyTimer = 0f;
                SpawnRandomObject();
            }
        }

        private int CalculateNextWaveAmount()
        {
            _numberOfEnemiesToSpawnNextWave += _wavesSpawnerConfig.ObjectPerWaveDifference;

            if (_numberOfEnemiesToSpawnNextWave > _wavesSpawnerConfig.MaxNumberOfObjectsToSpawn)
                _numberOfEnemiesToSpawnNextWave = _wavesSpawnerConfig.MaxNumberOfObjectsToSpawn;

            return _numberOfEnemiesToSpawnNextWave;
        }
    }
}