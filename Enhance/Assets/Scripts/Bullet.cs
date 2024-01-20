using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _timeToDestroy = 5f;

    private Transform _target;
    private Rigidbody2D _rb;
    private float _timer = 0;

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

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
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
}
