using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingController : Shooter
{
    [SerializeField] private float _distanceToShoot = 10f;

    private Transform _target;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }

    private void Update()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, _target.position);

        if (distanceToPlayer < _distanceToShoot)
        {
            ShootWithCooldown(_bullet, _bulletInitialPosition, _shootCooldown);
        }
    }
}
