using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : DamageableObject
{
    [SerializeField] private GameStatsController _gameStatsController;
    [SerializeField] private int _experienceAmount;

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

        if (collision.gameObject.CompareTag(Tags.PLAYER))
        {
            ReceiveDamage(_health);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.WEAPON_PROJECTILE))
        {
            ReceiveDamage(collision.gameObject.GetComponent<Bullet>().GetDamage());
        }

        // destroy enemy on collision with weapon
        if (collision.CompareTag(Tags.WEAPON))
        {
            ReceiveDamage(_health);
        }
    }

    private void EnemyHealthController_OnDie(object sender, EventArgs e)
    {
        FindObjectOfType<Player>().GetComponent<Player>()._levelUpSystem.AddExperience(_experienceAmount);
        _gameStatsController.EnemiesKilled++;
        Destroy(gameObject);
    }

}
