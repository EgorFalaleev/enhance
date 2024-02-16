using UnityEngine;

namespace Enhance.Runtime
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _timeToDestroy = 5f;
        [SerializeField] private int _damage = 1;

        private Transform _target;
        private Rigidbody2D _rb;
        private float _timer = 0;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void OnEnable()
        {
            _timer = 0f;
        
            // shoot the player
            if (gameObject.CompareTag(Tags.ENEMY_PROJECTILE))
                _target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
            // shoot the closest enemy
            else if (gameObject.CompareTag(Tags.WEAPON_PROJECTILE))
            {
                var closestEnemyFinder = GetComponent<ClosestEnemyFinder>();

                if (closestEnemyFinder.FindClosestEnemy())
                    _target = closestEnemyFinder.ClosestEnemy;
                else
                    ObjectPoolingManager.ReturnObjectToPool(gameObject);
            }

            AimAtTarget(_target);
        }

        protected virtual void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _timeToDestroy)
            {
                ObjectPoolingManager.ReturnObjectToPool(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ObjectPoolingManager.ReturnObjectToPool(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ObjectPoolingManager.ReturnObjectToPool(gameObject);
        }

        private void AimAtTarget(Transform target)
        {
            if (target != null)
            {
                // aim at target
                Vector3 direction = _target.position - transform.position;
                _rb.velocity = direction.normalized * _speed;

                transform.right = direction;
            }
        }

        public int GetDamage()
        {
            return _damage;
        }
    }
}
