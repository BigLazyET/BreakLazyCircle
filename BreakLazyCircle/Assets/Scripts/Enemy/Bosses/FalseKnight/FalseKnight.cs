using BreakLazyCircle.Combat;
using UnityEngine;

namespace BreakLazyCircle.Bosses
{
    public class FalseKnight : MonoBehaviour, IDestructable
    {
        [SerializeField]
        private DestructableData destructableData;

        public DestructableData DestructableData
        {
            get => destructableData;
            set => destructableData = value;
        }

        private int currentHealth;
        private bool invincible;

        private void Awake()
        {
            currentHealth = destructableData.Health;
            invincible = destructableData.Invincible;
        }

        public void DealDamage(int damage)
        {
            DestructableData.CurrentHealth -= damage;
            if (DestructableData.CurrentHealth <= 0)
            {
                
            }
        }

        public void Revive()
        {
            currentHealth = destructableData.Health;
        }
    }
}
