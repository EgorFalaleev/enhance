﻿namespace Enhance.Runtime
{
    public interface IDamageable
    {
        public void TakeDamage(int amount);
        public void Die();
    }
}