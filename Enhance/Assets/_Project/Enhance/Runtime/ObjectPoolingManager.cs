using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enhance.Runtime
{
    public class ObjectPoolingManager : MonoBehaviour
    {
        private static List<PooledObjectInfo> ObjectPools = new();
        private static List<GameObject> PooledObjectsContainers = new();

        private static GameObject _mainContainer;

        private void Awake()
        {
            _mainContainer = new GameObject("Pooled Objects");
        }

        private void Start()
        {
            ObjectPools.Clear();
            PooledObjectsContainers.Clear();
        }

        public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation)
        {
            // check if pool exists
            PooledObjectInfo pool = ObjectPools.Find(pool => pool.ObjectName == objectToSpawn.name);
        
            // check if parent container object for spawnable object exist
            string parentContainerName = objectToSpawn.name + "_Container";
            GameObject parentContainer = PooledObjectsContainers.Find(container => container.name == parentContainerName);

            // create pool if it doesn't exist
            if (pool == null)
            {
                pool = new PooledObjectInfo() { ObjectName = objectToSpawn.name };
                ObjectPools.Add(pool);

                parentContainer = new GameObject(parentContainerName);
                parentContainer.transform.SetParent(_mainContainer.transform);
                PooledObjectsContainers.Add(parentContainer);
            }

            // check for inactive objects in pool
            var spawnableObject = pool.InactiveObjects.FirstOrDefault();

            // inactive object doesn't exist, create new
            if (spawnableObject == null)
            {
                spawnableObject = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            
                // set parent object for spawned object
                if (parentContainer != null)
                {
                    spawnableObject.transform.SetParent(parentContainer.transform);
                }
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
}