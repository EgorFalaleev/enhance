using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public event EventHandler OnDie;
    public event EventHandler OnDamageTaken;

    [SerializeField] private int _health = 4;
    [SerializeField] private GameObject _dropItemPrefab;

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
        Destroy(gameObject);
    }

    public void ReceiveDamage(int amount)
    {
        _health -= amount;
        if (OnDamageTaken != null)
            OnDamageTaken(this, EventArgs.Empty);


        if (_health <= 0)
        {
            if (OnDie != null)
                OnDie(this, EventArgs.Empty);
        }
    }
}
