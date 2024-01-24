using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class DamageableObject : MonoBehaviour
{
    public event EventHandler OnDie;
    public event EventHandler OnDamageTaken;

    [SerializeField] private int _health = 4;

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
