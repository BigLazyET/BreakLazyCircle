using System;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "newHitTypeColorData", menuName = "Data/Combat Attackable Data/Hit Color Data")]
    public class HitTypeColorData : ScriptableObject, IHitTypeData
    {
        public HitType HitType => HitType.Color;

        [field: SerializeField] public Material HitMaterial { get; private set; }

        [field: SerializeField] public bool IsRecoveryBack {  get; private set; }

        [field: SerializeField] public float Duration { get; private set; }

        [field: SerializeField] public float Delay { get; private set; }
    }
}
