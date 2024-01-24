using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponVfxController : MonoBehaviour
{
    [Header("Death vfx")]
    [SerializeField] private GameObject _deathParticleSystem;

    void Start()
    {
        GetComponent<WeaponAttachController>().OnDie += WeaponVfxController_OnDie;
    }

    private void WeaponVfxController_OnDie(object sender, System.EventArgs e)
    {
        GameObject deathParticles = Instantiate(_deathParticleSystem, transform.position, Quaternion.identity);
        Destroy(deathParticles, deathParticles.GetComponent<ParticleSystem>().main.duration);
    }
}
