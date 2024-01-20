using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Transform _target;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

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
                Destroy(gameObject);
        }

        AimAtTarget(_target);
    }

    void Update()
    {
        
    }

    private void AimAtTarget(Transform target)
    {
        if (target != null)
        {
            // aim at target
            Vector3 direction = _target.position - transform.position;
            _rb.velocity = direction.normalized * speed;

            transform.right = direction;
        }
    }
}
