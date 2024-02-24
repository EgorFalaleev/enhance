using System;
using Enhance.Runtime.Player;
using UnityEngine;

namespace Enhance.Runtime.Weapon
{
    public class WeaponVfxController : MonoBehaviour
    {
        [Header("Death vfx")]
        [SerializeField] private GameObject _deathParticleSystem;

        [Header("Trail vfx")]
        [SerializeField] private TrailRenderer _trailRenderer;

        private PlayerController _playerController;
        private WeaponHealthController _weaponHealthController;

        void Start()
        {
            _weaponHealthController = GetComponent<WeaponHealthController>();
            _weaponHealthController.OnDie += WeaponVfxController_OnDie;

            _playerController = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerController>();
            _playerController.OnDashStart += _playerController_OnDashStart;
            _playerController.OnDashEnd += _playerController_OnDashEnd;
        }

        private void _playerController_OnDashEnd(object sender, EventArgs e)
        {
            if (_trailRenderer != null)
                _trailRenderer.emitting = false;
        }

        private void _playerController_OnDashStart(object sender, EventArgs e)
        {
            if (_trailRenderer != null)
                _trailRenderer.emitting = true;
        }

        private void WeaponVfxController_OnDie(object sender, EventArgs e)
        {
            _playerController.OnDashStart -= _playerController_OnDashStart;
            _playerController.OnDashEnd -= _playerController_OnDashEnd;

            ObjectPoolingManager.SpawnObject(_deathParticleSystem, transform.position, Quaternion.identity);
        }
    }
}
