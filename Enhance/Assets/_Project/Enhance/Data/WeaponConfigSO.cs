using UnityEngine;

namespace Enhance.Data
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "ScriptableObjects/WeaponConfig")]
    public class WeaponConfigSO : ScriptableObject
    {
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public float LifeTime { get; private set; }
        [field: SerializeField] public float ShootingCooldown { get; private set; }
    }
}
