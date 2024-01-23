using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public event EventHandler OnDie;

    [SerializeField] private GameObject _dropItemPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.WEAPON_PROJECTILE))
        {
            if (OnDie != null)
                OnDie(this, EventArgs.Empty);

            Instantiate(_dropItemPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}
