using System;
using UnityEngine;

namespace Enhance.Runtime
{
    public abstract class DamageableObject : MonoBehaviour
    {
        public event EventHandler OnDie;
        public event EventHandler OnDamageTaken;

        [SerializeField] protected int _health = 4;

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
}
