using UnityEngine;

namespace Combat
{
    public interface IHitTypeColorData : IHitTypeData
    {
        Material HitMaterial { get; }
    }
}
