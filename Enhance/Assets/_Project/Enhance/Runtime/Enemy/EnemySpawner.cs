using UnityEngine;

namespace Enhance.Runtime.Enemy
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private float _timeTillNextWave = 10f;
        [SerializeField] private float _timeTillSingleEnemy = 3f;
        [SerializeField] private int _maxEnemiesToSpawnPerWave = 25;
        [SerializeField] private int _enemiesPerWaveDifference = 2;

        private float _waveTimer = 0f;
        private float _singleEnemyTimer = 0f;
        private int _numberOfEnemiesToSpawnNextWave = 3;

        protected override void Update()
        {
            base.Update();

            _waveTimer += Time.deltaTime;
            _singleEnemyTimer += Time.deltaTime;

            if ( _waveTimer > _timeTillNextWave )
            {
                _waveTimer = 0f;

                SpawnMultipleObjects(CalculateNextWaveAmount());
            }

            if (_singleEnemyTimer > _timeTillSingleEnemy)
            {
                _singleEnemyTimer = 0f;
                SpawnRandomObject();
            }
        }

        private int CalculateNextWaveAmount()
        {
            _numberOfEnemiesToSpawnNextWave += _enemiesPerWaveDifference;

            if (_numberOfEnemiesToSpawnNextWave > _maxEnemiesToSpawnPerWave)
                _numberOfEnemiesToSpawnNextWave = _maxEnemiesToSpawnPerWave;

            return _numberOfEnemiesToSpawnNextWave;
        }
    }
}
