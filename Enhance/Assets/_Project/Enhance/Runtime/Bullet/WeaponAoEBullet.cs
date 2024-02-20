using UnityEngine;

namespace Enhance.Runtime.Bullet
{
    public class WeaponAoEBullet : WeaponBullet
    {
        [SerializeField] private float _scaleIncrement = 0.1f;

        private Vector3 _initialScale;

        // AoE projectiles do not destroy on collisions
        private void OnCollisionEnter2D(Collision2D collision)
        {
            DealDamageToDamageableObject(collision.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DealDamageToDamageableObject(collision.gameObject);
        }

        private void Start()
        {
            _initialScale = transform.localScale;
        }

        protected override void OnEnable()
        {
            transform.localScale = _initialScale;
            base.OnEnable();
        }

        protected override void Update()
        {
            // expand in size
            var newScale = new Vector3(transform.localScale.x + (_scaleIncrement * Time.deltaTime),
                transform.localScale.y + (_scaleIncrement * Time.deltaTime), transform.localScale.z);

            transform.localScale = newScale;
            base.Update();
        }
    }
}