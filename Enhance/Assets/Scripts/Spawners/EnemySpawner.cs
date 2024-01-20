using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _minSpawnRadius = 8f;
    [SerializeField] private float _maxSpawnRadius = 10f;
    [SerializeField] private float _timeTillNextWave = 10f;
    [SerializeField] private float _timeTillSingleEnemy = 3f;
    [SerializeField] private GameObject _spawnedEnemiesContainer;

    private float _waveTimer = 0f;
    private float _singleEnemyTimer = 0f;
    private int _numberEnemiesToSpawnNextWave = 10;

    void Start()
    {
        
    }

    void Update()
    {
        // need to spawn around player so spawner follows him
        transform.position = _playerTransform.position;

        _waveTimer += Time.deltaTime;
        _singleEnemyTimer += Time.deltaTime;

        if ( _waveTimer > _timeTillNextWave )
        {
            _waveTimer = 0f;

            SpawnWave();
        }

        if (_singleEnemyTimer > _timeTillSingleEnemy)
        {
            _singleEnemyTimer = 0f;
            SpawnSingleEnemy();
        }
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        float randomAngle = Random.Range(0, Mathf.PI * 2);
        float radius = Random.Range(_minSpawnRadius, _maxSpawnRadius);

        // generate a point on a circle
        Vector3 spawnPosition = new Vector3(transform.position.x + Mathf.Sin(randomAngle) * radius, transform.position.y + Mathf.Cos(randomAngle) * radius, transform.position.z);

        return spawnPosition; 
    }

    private void SpawnWave()
    {
        for (int i = 0; i < _numberEnemiesToSpawnNextWave; i++) 
        {
            SpawnSingleEnemy();
        }
    }

    private void SpawnSingleEnemy()
    {
        int randomEnemyIndex = Random.Range(0, _enemyPrefabs.Count);
        GameObject enemyToSpawn = _enemyPrefabs[randomEnemyIndex];

        GameObject newEnemy = Instantiate(enemyToSpawn, GenerateRandomSpawnPosition(), Quaternion.identity);
        newEnemy.transform.SetParent(_spawnedEnemiesContainer.transform);
    }
}
