using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour 
{
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected Transform _bulletInitialPosition;
    [SerializeField] protected float _shootCooldown = 2f;

    private float timer = 0f;

    void Update()
    {
        ShootWithCooldown(_bullet, _bulletInitialPosition, _shootCooldown);
    }

    protected void ShootWithCooldown(GameObject bulletPrefab, Transform bulletInitialPos, float cooldown)
    {
        timer += Time.deltaTime;

        // shoot periodically
        if (timer > cooldown)
        {
            timer = 0;
            Instantiate(bulletPrefab, bulletInitialPos.position, Quaternion.identity);
        }
    }
}
