using UnityEngine;

namespace Combat
{
    public class HitTypeColorData : ScriptableObject, IHitTypeColorData
    {
        public HitType HitType => HitType.Color;

        [field: SerializeField] public bool IsRecoveryBack { get; private set; }

        [field: SerializeField] public float Duration { get; private set; }

        [field: SerializeField] public float Delay { get; private set; }

        [field: SerializeField] public Material HitMaterial { get; private set; }
    }
}
