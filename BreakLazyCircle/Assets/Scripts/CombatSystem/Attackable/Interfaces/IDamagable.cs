using System;

namespace Combat
{
    public interface IDamagable
    {
        DamagableData DamagableData { get; }

        void OnAttackDamage(float damage);

        event Action OnDamage;

        event Action OnDestroyed;

        void Revive();
    }
}
