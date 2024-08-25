using CoreSystem;
using Combat;
using UnityEngine;

namespace BreakLazyCircle.Character
{
    public class Player : MonoBehaviour, IAttackable
    {
        private Core core;
        private Hittable hittable;
        private Damagable damageable;

        public static Player Instance;

        private void Update()
        {
            core.LogicUpdate();
        }

        private void Awake()
        {
            Instance ??= this;

            core = GetComponentInChildren<Core>();
            hittable = core.GetCoreComponent<Hittable>();
            damageable = core.GetCoreComponent<Damagable>();
        }

        public void OnAttacked(Vector2 hitPosition, Vector2 force, float damage)
        {
            hittable.OnAttackHit(hitPosition, force);
            damageable.OnAttackDamage(damage);
        }
    }
}
