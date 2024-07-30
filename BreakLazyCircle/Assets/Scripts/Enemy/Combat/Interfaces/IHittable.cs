using UnityEngine;

namespace BreakLazyCircle.Combat
{
    public interface IHittable
    {
        HittableData HittableData { get; }

        void OnAttackHit(Vector2 position, Vector2 force, int damage);
    }
}
