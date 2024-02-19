using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Weapon
{
    public class WeaponShooter : MonoBehaviour, IShooter
    {
        [SerializeField] private WeaponConfigSO _weaponConfig;
        [SerializeField] private BulletConfigSO _bulletConfig;
        
        public bool IsWeaponAttached { get; set; }

        private float _timer = 0f;
        private Transform _target;

        private void Update()
        {
            // dont't shoot if weapon is not attached
            if (!IsWeaponAttached)
                return;
            
            _timer += Time.deltaTime;

            if (_timer > _weaponConfig.ShootingCooldown)
            {
                _timer = 0f;
                Shoot(_bulletConfig, _target, transform);
            }
        }

        public void Shoot(BulletConfigSO bulletConfig, Transform target, Transform shootPosition)
        {
            if (!FindAndSetClosestEnemy())
                return;
            
            ObjectPoolingManager.SpawnObject(bulletConfig.BulletPrefab, shootPosition.position, Quaternion.identity);
        }
        
        private bool FindAndSetClosestEnemy()
        {
            // find all enemies within radius
            // TODO: replace with OverlapCircle()
            var enemyInRangeColliders = Physics2D.OverlapCircleAll(transform.position, _weaponConfig.AttackRange, LayerMask.GetMask("Enemy"));
        
            float shortestDistance = Mathf.Infinity;

            if (enemyInRangeColliders.Length > 0)
            {
                foreach (var enemy in enemyInRangeColliders)
                {
                    var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                    // update closest enemy
                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        _target = enemy.gameObject.transform;
                    }
                }
            }
            // no enemies in visible range
            else
                return false;

            return true;
        }
    }
}
