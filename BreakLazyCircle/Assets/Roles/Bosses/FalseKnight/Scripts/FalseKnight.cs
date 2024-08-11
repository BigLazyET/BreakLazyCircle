using Combat;
using CoreSystem;
using UnityEngine;

namespace BreakLazyCircle.Bosses
{
    /// <summary>
    /// 假骑士
    /// </summary>
    public class FalseKnight : MonoBehaviour, IAttackable
    {
        private Core core;
        private Hittable hittable;
        private Damagable damageable;

        private void Awake()
        {
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
