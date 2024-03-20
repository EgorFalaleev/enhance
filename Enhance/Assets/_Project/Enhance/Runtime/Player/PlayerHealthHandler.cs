using System;
using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Player
{
    public class PlayerHealthHandler : MonoBehaviour, IDamageable
    {
        [SerializeField] private PlayerConfigSO _playerConfig;

        public int CurrentHealth { get; private set; }

        public event EventHandler OnDamageTaken;
        public event EventHandler OnDie;

        private void Start()
        {
            Time.timeScale = 1f;

            CurrentHealth = _playerConfig.MaxHealth;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // bumping into enemy always deals 1 damage
            if (collision.gameObject.CompareTag(Tags.ENEMY))
            {
                TakeDamage(1);
            }
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            if (OnDamageTaken != null)
                OnDamageTaken(this, EventArgs.Empty);


            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            if (OnDie != null)
                OnDie(this, EventArgs.Empty);
        
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0f;
        }
    }
}
