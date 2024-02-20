using UnityEngine;

namespace Enhance.Data
{
    [CreateAssetMenu(fileName = "WavesSpawnerConfig", menuName = "ScriptableObjects/WavesSpawnerConfig")]
    public class WavesSpawnerConfigSO : ScriptableObject
    {
        [field: SerializeField] public float TimeTillNextWave { get; private set; }
        [field: SerializeField] public int MaxNumberOfObjectsToSpawn { get; private set; }
        [field: SerializeField] public int ObjectPerWaveDifference { get; private set; }
    }
}