using System;
using UnityEngine;

public class PlayerHealthHandler : DamageableObject
{
    private void Start()
    {
        OnDie += PlayerHealthHandler_OnDie;
    }

    private void PlayerHealthHandler_OnDie(object sender, EventArgs e)
    {
        Destroy(gameObject); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.ENEMY_PROJECTILE))
        {
            ReceiveDamage(collision.gameObject.GetComponent<Bullet>().GetDamage());
        }
        // bumping into enemy always deals 1 damage
        else if (collision.gameObject.CompareTag(Tags.ENEMY))
        {
            ReceiveDamage(1);
        }
    }

    public int GetHealth()
    {
        return _health;
    }
}
