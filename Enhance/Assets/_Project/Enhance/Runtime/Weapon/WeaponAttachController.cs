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

        private bool _isAttached;
        private float _timer = 0f;
        private Transform _parent;
        private Transform _attachedObjectTransform;
        private LineRenderer _lineRenderer;

        private void Start()
        {
            CurrentHealth = _weaponConfig.MaxHealth;
            _parent = transform.parent.gameObject.transform;
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            if (_isAttached)
            {
                DrawAttachmentLine(transform.position, _attachedObjectTransform.position);
                return;
            }

            _timer += Time.deltaTime;
            
            if (_timer >= _weaponConfig.LifeTime)
                Die();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // enemy contact with weapon destroys it
            if (collision.CompareTag(Tags.ENEMY))
            {
                TakeDamage(CurrentHealth);
            }

            // can attach only once 
            if (!_isAttached)
            {
                // calculate the direction of attachment
                var direction = transform.position - collision.transform.position;

                // attach to a collision GO
                _parent.SetParent(collision.transform, false);
                _parent.localPosition = direction.normalized;

                _attachedObjectTransform = collision.transform;
                
                _isAttached = true;

                // weapon can shoot now
                //GetComponentInChildren<WeaponShooter>().IsWeaponAttached = true;
            }
        }

        private void DrawAttachmentLine(Vector3 from, Vector3 to)
        {
            _lineRenderer.positionCount = 2;
            
            _lineRenderer.SetPosition(0, from);
            _lineRenderer.SetPosition(1, to);
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