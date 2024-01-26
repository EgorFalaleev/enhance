using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVfxController : MonoBehaviour
{
    [Header("Flash parameters")]
    [SerializeField] private float _flashDurationInSeconds = 0.2f;

    [Header("Death vfx")]
    [SerializeField] private GameObject _deathParticleSystem;

    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private Coroutine _flashCoroutine;


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;

        GetComponent<PlayerHealthHandler>().OnDamageTaken += PlayerVfxController_OnDamageTaken; ;
        GetComponent<PlayerHealthHandler>().OnDie += PlayerVfxController_OnDie; ;
    }

    private void PlayerVfxController_OnDamageTaken(object sender, System.EventArgs e)
    {
        Flash();
    }

    private void PlayerVfxController_OnDie(object sender, System.EventArgs e)
    {
        GameObject deathParticles = Instantiate(_deathParticleSystem, transform.position, Quaternion.identity);
        Destroy(deathParticles, deathParticles.GetComponent<ParticleSystem>().main.duration);
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
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(_flashDurationInSeconds);

        // return to original settings
        _spriteRenderer.color = _originalColor;
        _flashCoroutine = null;
    }

}
