using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _prefabsToSpawn;
    [SerializeField] protected Transform _spawnCenter;
    [SerializeField] protected float _minSpawnRadius = 8f;
    [SerializeField] protected float _maxSpawnRadius = 10f;

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
        int randomObjectIndex = Random.Range(0, _prefabsToSpawn.Count);
        GameObject objectToSpawn = _prefabsToSpawn[randomObjectIndex];

        SpawnSpecificObject(objectToSpawn);
    }

    protected void SpawnSpecificObject(GameObject objectToSpawn)
    {
        ObjectPoolingManager.SpawnObject(objectToSpawn, GenerateRandomSpawnPosition(), Quaternion.identity);
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
