using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestEnemyFinder : MonoBehaviour
{
    public Transform ClosestEnemy {  get; private set; }

    [SerializeField] private float _visionRadius = 10f;
    [SerializeField] private LayerMask _enemyLayerMask;

    public bool FindClosestEnemy()
    {
        // remove later, visible range radius
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + _visionRadius, transform.position.y + _visionRadius, transform.position.z));

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
        else
            return false;

        return true;
    }
}
