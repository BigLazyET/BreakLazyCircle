using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "newKnockbackData", menuName = "Data/Combat Data/Base Knockback Data")]
    public class HitTypeKnockbackData : ScriptableObject, IHitTypeKnockbackData
    {
        public HitType HitType => HitType.Knockback;

        [field: SerializeField] public Vector3 KnockbackForce { get; private set; }

        [field: SerializeField] public bool IsRecoveryBack { get; private set; }

        [field: SerializeField] public float Duration { get; private set; }

        [field: SerializeField] public float Delay { get; private set; }
    }
}
