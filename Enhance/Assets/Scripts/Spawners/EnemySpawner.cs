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

    private float _timer = 0f;
    private int _enemyIndex;
    private int _numberEnemiesToSpawnNextWave = 10;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = _playerTransform.position;

        _timer += Time.deltaTime;

        if ( _timer > _timeTillNextWave )
        {
            _timer = 0f;

            int randomEnemyIndex = Random.Range(0, _enemyPrefabs.Count);
            GameObject enemyToSpawn = _enemyPrefabs[randomEnemyIndex];

            Instantiate(enemyToSpawn, GenerateRandomSpawnPosition(), Quaternion.identity);
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
}
