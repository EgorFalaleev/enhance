using System;
using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Weapon
{
    public class WeaponShooter : MonoBehaviour, IShooter
    {
        [SerializeField] private WeaponConfigSO _weaponConfig;
        [SerializeField] private BulletConfigSO _bulletConfig;
        [SerializeField] private WeaponAttachController _weaponAttachController;

        private bool _isWeaponAttached;
        private float _timer = 0f;

        private void Start()
        {
            _weaponAttachController.OnWeaponAttached += WeaponAttachController_OnWeaponAttached;
        }

        private void WeaponAttachController_OnWeaponAttached(object sender, EventArgs e)
        {
            _isWeaponAttached = true;
        }

        private void Update()
        {
            // don't shoot if weapon is not attached
            if (!_isWeaponAttached)
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
            ObjectPoolingManager.SpawnObject(bulletConfig.BulletPrefab, shootPosition.position, Quaternion.identity);
        }
    }
}