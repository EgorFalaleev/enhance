using UnityEngine;

namespace Enhance.Runtime.Bullet
{
    public class EnemyBullet : Bullet
    {
        protected override void OnEnable()
        {
            _target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;

            var distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);

            if (distanceToTarget > _bulletConfig.DetectionRadius)
                ObjectPoolingManager.ReturnObjectToPool(gameObject);
            
            base.OnEnable();
        }
    }
}