using UnityEngine;

namespace Enhance.Data
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "ScriptableObjects/BulletConfig")]
    public class BulletConfigSO : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _lifeTime;
    }
}
