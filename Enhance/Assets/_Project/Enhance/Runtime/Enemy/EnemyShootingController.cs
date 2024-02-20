using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Enemy
{
    public class EnemyShootingController : MonoBehaviour, IShooter
    {
        [SerializeField] private EnemyConfigSO _enemyConfig;
        [SerializeField] private BulletConfigSO _bulletConfig;

        private float _timer = 0f;

        private void Update()
        {
            _timer += Time.deltaTime;

            // shoot periodically
            if (_timer > _enemyConfig.ShootingCooldown)
            {
                _timer = 0;
                Shoot(_bulletConfig, transform);
            }
        }

        public void Shoot(BulletConfigSO bulletConfig, Transform shootPosition)
        {
            ObjectPoolingManager.SpawnObject(bulletConfig.BulletPrefab, shootPosition.position, Quaternion.identity);
        }
    }
}