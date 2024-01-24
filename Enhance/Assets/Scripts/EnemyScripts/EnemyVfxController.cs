using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVfxController : MonoBehaviour
{
    [Header("Flash parameters")]
    [SerializeField] private float _flashDurationInSeconds = 0.2f;

    [Header("Death vfx")]
    [SerializeField] private GameObject _deathParticleSystem;
    [SerializeField] private Color _flashColor;

    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private Coroutine _flashCoroutine;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;

        GetComponent<EnemyHealthController>().OnDamageTaken += EnemyVfxController_OnDamageTaken;
        GetComponent<EnemyHealthController>().OnDie += EnemyVfxController_OnDie;
    }

    private void EnemyVfxController_OnDie(object sender, System.EventArgs e)
    {
        GameObject deathParticles = Instantiate(_deathParticleSystem, transform.position, Quaternion.identity);
        Destroy(deathParticles, deathParticles.GetComponent<ParticleSystem>().main.duration);
    }

    private void EnemyVfxController_OnDamageTaken(object sender, System.EventArgs e)
    {
        Flash();
    }

    private void Flash()
    {
        // should not execute multiple flash coroutines simultaneously
        if (_flashCoroutine != null)
        {
            StopCoroutine(_flashCoroutine);
        }

        _flashCoroutine = StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        _spriteRenderer.color = _flashColor;

        yield return new WaitForSeconds(_flashDurationInSeconds);

        // return to original settings
        _spriteRenderer.color = _originalColor;
        _flashCoroutine = null;
    }
}
