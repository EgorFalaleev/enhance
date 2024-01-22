using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private GameObject _dropItemPrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.WEAPON_PROJECTILE))
        {
            Instantiate(_dropItemPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}
