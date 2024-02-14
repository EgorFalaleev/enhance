using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        // check if pool exists
        PooledObjectInfo pool = ObjectPools.Find(pool => pool.ObjectName == objectToSpawn.name);

        // create pool if it doesn't exist
        if (pool == null)
        {
            pool = new PooledObjectInfo() { ObjectName = objectToSpawn.name };
            ObjectPools.Add(pool);
        }

        // check for inactive objects in pool
        var spawnableObject = pool.InactiveObjects.FirstOrDefault();

        // inactive object doesn't exist, create new
        if (spawnableObject == null)
        {
            spawnableObject = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
        }
        // inactive object exists, use it
        else
        {
            spawnableObject.transform.position = spawnPosition;
            spawnableObject.transform.rotation = spawnRotation;

            pool.InactiveObjects.Remove(spawnableObject);
            
            spawnableObject.SetActive(true);
        }

        return spawnableObject;
    }

    public static void ReturnObjectToPool(GameObject objectToReturn)
    {
        // remove the (Clone) from the object name
        string correctObjectName = objectToReturn.name.Substring(0, objectToReturn.name.Length - 7);

        PooledObjectInfo pool = ObjectPools.Find(pool => pool.ObjectName == correctObjectName);

        if (pool == null)
        {
            Debug.LogWarning($"Trying to return non-pooled object: {objectToReturn.name}");
        }
        else
        {
            objectToReturn.SetActive(false);
            pool.InactiveObjects.Add(objectToReturn);
        }
    }
}

public class PooledObjectInfo
{
    public string ObjectName;
    public List<GameObject> InactiveObjects = new List<GameObject>();
}
