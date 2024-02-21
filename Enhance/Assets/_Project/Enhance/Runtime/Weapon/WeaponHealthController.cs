using System;
using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Weapon
{
    public class WeaponHealthController : MonoBehaviour, IDamageable
    {
        [SerializeField] private WeaponConfigSO _weaponConfig;

        public int CurrentHealth { get; private set; }

        public event EventHandler OnDie;

        private float _timer = 0f;

        private void Start()
        {
            CurrentHealth = _weaponConfig.MaxHealth;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _weaponConfig.LifeTime)
                Die();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // enemy contact with weapon destroys it
            if (other.CompareTag(Tags.ENEMY))
            {
                TakeDamage(CurrentHealth);
            }
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;

            Debug.Log(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            if (OnDie != null)
                OnDie(this, EventArgs.Empty);

            Destroy(gameObject);
        }
    }
}