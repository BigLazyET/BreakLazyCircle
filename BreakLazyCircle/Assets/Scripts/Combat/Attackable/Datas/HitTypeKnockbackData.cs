using System;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "newHitTypeKnockbackData", menuName = "Data/Combat Attackable Data/Hit Knockback Data")]
    public class HitTypeKnockbackData : ScriptableObject, IHitTypeData
    {
        public HitType HitType => HitType.Knockback;

        [field: SerializeField] public Vector3 KnockbackForce { get; private set; }

        public bool IsRecoveryBack { get; private set; }

        public float Duration { get; private set; }

        public float Delay { get; private set; }
    }
}
