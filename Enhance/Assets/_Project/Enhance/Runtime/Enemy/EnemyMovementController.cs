using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private EnemyConfigSO _enemyConfig;
        
        private Transform _target;
        private Rigidbody2D _rb;
        private Vector3 _moveDirection;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        }

        private void FixedUpdate()
        {
            LookAtTarget(_target);

            // determine direction to move
            var direction = _target.position - transform.position;
            _moveDirection = direction.normalized;

            _rb.velocity = Time.fixedDeltaTime * _enemyConfig.MoveSpeed * _moveDirection;
        }

        private void LookAtTarget(Transform target)
        {
            transform.right = target.position - transform.position;
        }
    }
}
