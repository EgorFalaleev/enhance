using UnityEngine;

namespace Enhance.Runtime
{
    public abstract class Shooter : MonoBehaviour 
    {
        [SerializeField] protected GameObject _bullet;
        [SerializeField] protected Transform _bulletInitialPosition;
        [SerializeField] protected float _shootCooldown = 2f;

        private float _timer = 0f;

        void Update()
        {
            ShootWithCooldown(_bullet, _bulletInitialPosition, _shootCooldown);
        }

        protected void ShootWithCooldown(GameObject bulletPrefab, Transform bulletInitialPos, float cooldown)
        {
            _timer += Time.deltaTime;

            // shoot periodically
            if (_timer > cooldown)
            {
                _timer = 0;
                ObjectPoolingManager.SpawnObject(bulletPrefab, bulletInitialPos.position, Quaternion.identity);
            }
        }
    }
}
