using System;
using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Weapon
{
    public class WeaponAttachController : MonoBehaviour, IDamageable
    {
        [SerializeField] private WeaponConfigSO _weaponConfig;

        public event EventHandler OnDie;
        
        public int CurrentHealth { get; private set; }

        private const float WEAPON_ATTACH_MODIFIER = 1.25f;
        private const float PLAYER_ATTACH_MODIFIER = 0.9f;

        private bool _isAttached;
        private float _timer = 0f;

        private void Start()
        {
            CurrentHealth = _weaponConfig.MaxHealth;
        }

        private void Update()
        {
            if (_isAttached)
                return;

            _timer += Time.deltaTime;
            
            if (_timer >= _weaponConfig.LifeTime)
                Die();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // enemy contact with weapon destroys it
            if (collision.CompareTag(Tags.ENEMY) || collision.CompareTag(Tags.ENEMY_PROJECTILE))
            {
                TakeDamage(CurrentHealth);
            }

            // can attach only once 
            if (!_isAttached)
            {
                // calculate the direction of attachment
                var direction = transform.position - collision.transform.position;

                // attach to a collision GO
                transform.SetParent(collision.transform, false);
                transform.localPosition = collision.CompareTag(Tags.WEAPON) ? direction.normalized * WEAPON_ATTACH_MODIFIER: direction.normalized * PLAYER_ATTACH_MODIFIER;

                // change scale to 1 if attached to another weapon to prevent getting smaller
                if (collision.CompareTag(Tags.WEAPON))
                    transform.localScale = Vector3.one;

                _isAttached = true;

                // weapon can shoot now
                GetComponentInChildren<WeaponShooter>().IsWeaponAttached = true;
            }
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;

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
