using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour 
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
            Shoot(_bullet, _bulletInitialPosition);
        }
    }

    private void Shoot(GameObject bulletPrefab, Transform bulletInitialPos)
    {
        Instantiate(bulletPrefab, bulletInitialPos.position, Quaternion.identity);
    }
}
