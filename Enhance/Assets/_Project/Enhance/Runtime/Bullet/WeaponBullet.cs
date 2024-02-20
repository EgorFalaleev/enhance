using UnityEngine;

namespace Enhance.Runtime.Bullet
{
    public class WeaponBullet : Bullet
    {
        protected override void OnEnable()
        {
            if (!FindAndSetClosestEnemy())
                ObjectPoolingManager.ReturnObjectToPool(gameObject);
            
            base.OnEnable();
        }
        
        private bool FindAndSetClosestEnemy()
        {
            // find all enemies within radius
            // TODO: replace with OverlapCircle()
            var enemyInRangeColliders = Physics2D.OverlapCircleAll(transform.position, _bulletConfig.DetectionRadius, LayerMask.GetMask("Enemy"));
        
            float shortestDistance = Mathf.Infinity;

            if (enemyInRangeColliders.Length > 0)
            {
                foreach (var enemy in enemyInRangeColliders)
                {
                    var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                    // update closest enemy
                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        _target = enemy.gameObject.transform;
                    }
                }
            }
            // no enemies in visible range
            else
                return false;

            return true;
        }
    }
}