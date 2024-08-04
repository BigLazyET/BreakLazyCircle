using CoreSystem;
using System;
using UnityEngine;

namespace Combat
{
    public class Damagable : CoreComponent, IDamagable
    {
        [field: SerializeField] public DamagableData DamagableData { get; private set; }

        private float health;
        private bool isvincible;

        public float CurrentHealth { get; set; }

        public event Action OnDamage;
        public event Action OnDestroyed;

        protected override void Awake()
        {
            base.Awake();

            health = DamagableData.Health;
            isvincible = DamagableData.Invincible;

            CurrentHealth = health;
        }

        public void OnAttackDamage(float damage)
        {
            if (isvincible) return;

            // TODO: damage modifier buff system
            CurrentHealth -= damage;
            OnDamage?.Invoke();

            if (CurrentHealth < 0)
                OnDestroyed?.Invoke();
        }

        public void Revive() => CurrentHealth = health;
    }
}
