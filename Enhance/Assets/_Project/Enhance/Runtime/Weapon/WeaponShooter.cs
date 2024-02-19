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
                Shoot(_bulletConfig, transform);
            }
        }

        public void Shoot(BulletConfigSO bulletConfig, Transform shootPosition)
        {
            if (!FindAndSetClosestEnemy())
                return;
            
            ObjectPoolingManager.SpawnObject(bulletConfig.BulletPrefab, shootPosition.position, Quaternion.identity);
        }
        
        
    }
}
