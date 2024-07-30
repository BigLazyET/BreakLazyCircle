using System;
using UnityEngine;

namespace BreakLazyCircle.Combat
{
    [CreateAssetMenu(fileName = "newDestructableData", menuName = "Data/Combat Data/Base Destructable Data")]
    public class DestructableData : ScriptableObject, IDestructableData
    {
        [SerializeField]
        private int health, currentHealth;
        [SerializeField]
        private bool invincible;

        public int Health { get => health; set => health = value; }

        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

        public bool Invincible { get => invincible; set => invincible = value; }
    }
}
