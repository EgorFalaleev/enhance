using UnityEngine;

namespace Enhance.Runtime
{
    public class ClosestEnemyFinder : MonoBehaviour
    {
        public Transform ClosestEnemy {  get; private set; }

        [SerializeField] private float _visionRadius = 10f;
        [SerializeField] private LayerMask _enemyLayerMask;

        public bool FindClosestEnemy()
        {
            // find all enemies within radius
            var enemyInRangeColliders = Physics2D.OverlapCircleAll(transform.position, _visionRadius, _enemyLayerMask);
        
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
                        ClosestEnemy = enemy.gameObject.transform;
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
