using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletInitialPosition;
    [SerializeField] private float shootCooldown = 2f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        // shoot periodically
        if (timer > shootCooldown)
        {
            timer = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _bulletInitialPosition.position, Quaternion.identity);
    }
}
