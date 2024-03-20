using System;
using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Enemy
{
    public class EnemyHealthController : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemyConfigSO _enemyConfig;

        private SpriteRenderer _spriteRenderer;

        public int CurrentHealth { get; private set; }

        public event EventHandler OnDamageTaken;
        public event EventHandler OnDie;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            ResetEnemyState();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // collision with player kills enemy
            if (collision.gameObject.CompareTag(Tags.PLAYER))
            {
                TakeDamage(CurrentHealth);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // destroy enemy on collision with weapon
            if (collision.CompareTag(Tags.WEAPON))
            {
                TakeDamage(CurrentHealth);
            }
        }

        private void ResetEnemyState()
        {
            CurrentHealth = _enemyConfig.MaxHealth;
            _spriteRenderer.color = _enemyConfig.InitialColor;
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
            
            FindObjectOfType<Player.Player>().GetComponent<Player.Player>().LevelSystem
                .AddExperience(_enemyConfig.ExperienceAmount);
            GameStatsController.Instance.EnemiesKilled++;

            ObjectPoolingManager.ReturnObjectToPool(gameObject);
        }
    }
}