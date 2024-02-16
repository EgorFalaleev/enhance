using System;
using UnityEngine;

namespace Enhance.Runtime.Enemy
{
    public class EnemyHealthController : DamageableObject
    {
        [SerializeField] private GameStatsController _gameStatsController;
        [SerializeField] private int _experienceAmount;

        private int _maxHealth;
        private Color _defaultColor;
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _maxHealth = _health;
            _renderer = GetComponent<SpriteRenderer>();
            _defaultColor = _renderer.color;
        }

        private void Start()
        {
            OnDie += EnemyHealthController_OnDie;
        }

        private void OnEnable()
        {
            ResetEnemyState();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Tags.WEAPON_PROJECTILE))
            {
                ReceiveDamage(collision.gameObject.GetComponent<Bullet>().GetDamage());
            }

            if (collision.gameObject.CompareTag(Tags.PLAYER))
            {
                ReceiveDamage(_health);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Tags.WEAPON_PROJECTILE))
            {
                ReceiveDamage(collision.gameObject.GetComponent<Bullet>().GetDamage());
            }

            // destroy enemy on collision with weapon
            if (collision.CompareTag(Tags.WEAPON))
            {
                ReceiveDamage(_health);
            }
        }

        private void EnemyHealthController_OnDie(object sender, EventArgs e)
        {
            FindObjectOfType<Player.Player>().GetComponent<Player.Player>()._levelUpSystem.AddExperience(_experienceAmount);
            _gameStatsController.EnemiesKilled++;
        
            ObjectPoolingManager.ReturnObjectToPool(gameObject);
        }

        private void ResetEnemyState()
        {
            // TODO: refactor to set state from config
            _health = _maxHealth;
            _renderer.color = _defaultColor;
        }
    }
}
