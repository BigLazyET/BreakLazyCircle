using BreakLazyCircle.CoreSystem;
using System;
using UnityEngine;

namespace Combat
{
    public class Damagable : CoreComponent, IDamagable
    {
        [field: SerializeField] public DamagableData DamagableData { get; }

        private float health;
        private bool isvincible;

        private float currentHealth;

        public event Action OnDamage;
        public event Action OnDestroyed;

        protected override void Awake()
        {
            base.Awake();

            health = DamagableData.Health;
            isvincible = DamagableData.Invincible;

            currentHealth = health;
        }

        public void OnAttackDamage(float damage)
        {
            if (isvincible) return;

            // TODO: damage modifier buff system
            currentHealth -= damage;
            OnDamage?.Invoke();

            if (currentHealth < 0)
                OnDestroyed?.Invoke();
        }

        public void Revive() => currentHealth = health;
    }
}
