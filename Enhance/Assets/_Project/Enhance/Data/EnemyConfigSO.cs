using UnityEngine;

namespace Enhance.Data
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig")]
    public class EnemyConfigSO : ScriptableObject
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _attackRange;
    }
}
