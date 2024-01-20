using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestEnemyFinder : MonoBehaviour
{
    [SerializeField] private float _visionRadius;
    [SerializeField] private LayerMask _enemyLayerMask;

    public GameObject FindClosestEnemy()
    {
        // remove later, visible range radius
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + _visionRadius, transform.position.y + _visionRadius, transform.position.z));

        // find all enemies within radius
        var enemyInRangeColliders = Physics2D.OverlapCircleAll(transform.position, _visionRadius, _enemyLayerMask);
        
        GameObject closestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (var enemy in enemyInRangeColliders)
        {
            var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            // update closest enemy
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy.gameObject;
            }
        }

        return closestEnemy;
    }
}
