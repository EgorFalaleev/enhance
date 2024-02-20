using System;
using System.Collections.Generic;
using Enhance.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enhance.Runtime
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected SpawnerConfigSO _spawnerConfig;
        
        protected Transform _spawnCenter;

        protected virtual void Start()
        {
            _spawnCenter = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        }

        protected virtual void Update()
        {
            transform.position = _spawnCenter.position;
        }

        protected void SpawnMultipleObjects(int numberOfObjectsToSpawn)
        {
            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
                SpawnRandomObject();
            }
        }

        protected void SpawnRandomObject()
        {
            var randomObjectIndex = Random.Range(0, _spawnerConfig.PrefabsToSpawn.Count);
            var objectToSpawn = _spawnerConfig.PrefabsToSpawn[randomObjectIndex];

            SpawnSpecificObject(objectToSpawn);
        }

        protected void SpawnSpecificObject(GameObject objectToSpawn)
        {
            ObjectPoolingManager.SpawnObject(objectToSpawn, GenerateRandomSpawnPosition(), Quaternion.identity);
        }

        private Vector3 GenerateRandomSpawnPosition()
        {
            var randomAngle = Random.Range(0, Mathf.PI * 2);
            var radius = Random.Range(_spawnerConfig.MinSpawnRadius, _spawnerConfig.MaxSpawnRadius);

            // generate a point on a circle
            var spawnPosition = new Vector3(transform.position.x + Mathf.Sin(randomAngle) * radius, transform.position.y + Mathf.Cos(randomAngle) * radius, transform.position.z);

            return spawnPosition;
        }

    }
}
