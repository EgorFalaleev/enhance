using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponVfxController : MonoBehaviour
{
    [Header("Death vfx")]
    [SerializeField] private GameObject _deathParticleSystem;

    [Header("Trail vfx")]
    [SerializeField] private TrailRenderer _trailRenderer;

    private PlayerController _playerController;
    private WeaponAttachController _weaponAttachController;

    void Start()
    {
        _weaponAttachController = GetComponent<WeaponAttachController>();
        _weaponAttachController.OnDie += WeaponVfxController_OnDie;

        _playerController = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerController>();
        _playerController.OnDashStart += _playerController_OnDashStart;
        _playerController.OnDashEnd += _playerController_OnDashEnd;
    }

    private void _playerController_OnDashEnd(object sender, System.EventArgs e)
    {
        if (_trailRenderer != null)
        _trailRenderer.emitting = false;
    }

    private void _playerController_OnDashStart(object sender, System.EventArgs e)
    {
        if (_trailRenderer != null)
        _trailRenderer.emitting = true;
    }

    private void WeaponVfxController_OnDie(object sender, System.EventArgs e)
    {
        _playerController.OnDashStart -= _playerController_OnDashStart;
        _playerController.OnDashEnd -= _playerController_OnDashEnd;
        GameObject deathParticles = Instantiate(_deathParticleSystem, transform.position, Quaternion.identity);
        Destroy(deathParticles, deathParticles.GetComponent<ParticleSystem>().main.duration);
    }

    public void StartDashing()
    {
        _trailRenderer.emitting = true;
    }

    public void StopDashing()
    {
        _trailRenderer.emitting = false;
    }
}