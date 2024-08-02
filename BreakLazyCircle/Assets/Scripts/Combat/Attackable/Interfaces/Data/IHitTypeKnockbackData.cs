using UnityEngine;

namespace Combat
{
    public interface IHitTypeKnockbackData : IHitTypeData
    {
        Vector3 KnockbackForce { get; }
    }
}
