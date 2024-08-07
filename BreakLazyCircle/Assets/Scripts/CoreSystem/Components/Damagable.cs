using CoreSystem;
using System;
using UnityEngine;

namespace Combat
{
    public class Damagable : CoreComponent, IDamagable
    {
        [field: SerializeField] public DamagableData DamagableData { get; private set; }
        [field: SerializeField] public float CurrentHealth { get; set; }
        [field: SerializeField] public bool Invincible { get; set; }

        public event Action OnDamage;
        public event Action OnDestroyed;

        protected override void Awake()
        {
            base.Awake();

            CurrentHealth = DamagableData.Health;
        }

        public void OnAttackDamage(float damage)
        {
            if (Invincible) return;

            // TODO: damage modifier buff system
            CurrentHealth -= damage;
            OnDamage?.Invoke();

            if (CurrentHealth < 0)
                OnDestroyed?.Invoke();
        }

        public void Revive() => CurrentHealth = DamagableData.Health;
    }
}
