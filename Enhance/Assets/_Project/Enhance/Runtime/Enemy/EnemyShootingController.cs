using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Enemy
{
    public class EnemyShootingController : MonoBehaviour, IShooter
    {
        [SerializeField] private EnemyConfigSO _enemyConfig;
        [SerializeField] private BulletConfigSO _bulletConfig;

        private Transform _target;
        private float _timer = 0f;

        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        }

        private void Update()
        {
            var distanceToPlayer = Vector3.Distance(transform.position, _target.position);
            _timer += Time.deltaTime;
            
            // shoot periodically
            if (_timer > _enemyConfig.ShootingCooldown)
            {
                _timer = 0;
                if (distanceToPlayer < _enemyConfig.AttackRange)
                {
                    Shoot(_bulletConfig, _target, transform);
                }
            }
        }

        public void Shoot(BulletConfigSO bulletConfig, Transform target, Transform shootPosition)
        {
            ObjectPoolingManager.SpawnObject(bulletConfig.BulletPrefab, shootPosition.position, Quaternion.identity);
        }
    }
}