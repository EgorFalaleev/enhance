using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : DamageableObject
{
    [SerializeField] private GameObject _dropItemPrefab;
    [SerializeField] private GameStatsController _gameStatsController;

    private void Start()
    {
        OnDie += EnemyHealthController_OnDie;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.WEAPON_PROJECTILE))
        {
            ReceiveDamage(collision.gameObject.GetComponent<Bullet>().GetDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.WEAPON_PROJECTILE))
        {
            ReceiveDamage(collision.gameObject.GetComponent<Bullet>().GetDamage());
        }
    }

    private void EnemyHealthController_OnDie(object sender, EventArgs e)
    {
        Instantiate(_dropItemPrefab, transform.position, Quaternion.identity);
        _gameStatsController.EnemiesKilled++;
        Destroy(gameObject);
    }

}
