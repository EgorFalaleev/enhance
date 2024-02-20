using System.Collections.Generic;
using UnityEngine;

namespace Enhance.Data
{
    [CreateAssetMenu(fileName = "SpawnerConfig", menuName = "ScriptableObjects/SpawnerConfig")]
    public class SpawnerConfigSO : ScriptableObject
    {
        [field: SerializeField] public List<GameObject> PrefabsToSpawn { get; private set; }
        [field: SerializeField] public float MinSpawnRadius { get; private set; }
        [field: SerializeField] public float MaxSpawnRadius { get; private set; }
        [field: SerializeField] public float TimeTillNextObjectSpawn { get; private set; }
    }
}