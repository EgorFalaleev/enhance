using UnityEngine;

namespace Enhance.Data
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig")]
    public class EnemyConfigSO : ScriptableObject
    {
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public float ShootingCooldown { get; private set; }
        [field: SerializeField] public int ExperienceAmount { get; private set; }
        [field: SerializeField] public Color InitialColor { get; private set; }
        [field: SerializeField] public Color FlashColor { get; private set; }
    }
}
