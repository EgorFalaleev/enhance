using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Bullet
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] protected BulletConfigSO _bulletConfig;

        protected Transform _target;

        private Rigidbody2D _rb;
        private float _timer = 0;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void OnEnable()
        {
            _timer = 0f;

            if (_target != null)
                MoveToTarget(_target);
        }

        protected virtual void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _bulletConfig.LifeTime)
            {
                ObjectPoolingManager.ReturnObjectToPool(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            DealDamageToDamageableObject(collision.gameObject);

            ObjectPoolingManager.ReturnObjectToPool(gameObject);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            DealDamageToDamageableObject(collision.gameObject);

            ObjectPoolingManager.ReturnObjectToPool(gameObject);
        }

        protected void DealDamageToDamageableObject(GameObject objectToDealDamage)
        {
            var damageableObject = objectToDealDamage.GetComponent<IDamageable>();

            if (damageableObject != null)
            {
                Debug.Log($"damage from {gameObject.name} to {objectToDealDamage.name}");
                damageableObject.TakeDamage(_bulletConfig.Damage);
            }
        }

        private void MoveToTarget(Transform target)
        {
            // aim at target
            Vector3 direction = target.position - transform.position;
            _rb.velocity = direction.normalized * _bulletConfig.Speed;

            transform.right = direction;
        }

        public int GetDamage()
        {
            return _bulletConfig.Damage;
        }
    }
}