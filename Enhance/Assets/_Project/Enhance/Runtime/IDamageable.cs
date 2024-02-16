namespace Enhance.Runtime
{
    public interface IDamageable
    {
        public int CurrentHealth { get; }
        public void TakeDamage(int amount);
        public void Die();
    }
}