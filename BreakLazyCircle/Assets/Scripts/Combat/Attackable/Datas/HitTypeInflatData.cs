using System;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "newHitTypeInflatData", menuName = "Data/Combat Attackable Data/Hit Inflat Data")]
    public class HitTypeInflatData : ScriptableObject, IHitTypeData
    {
        public HitType HitType => HitType.Inflate;

        [field: SerializeField] public float XScale {  get; set; }
        [field: SerializeField] public float YScale {  get; set; }
        [field: SerializeField] public float ZScale {  get; set; }

        public bool IsRecoveryBack { get; private set; }

        public float Duration { get; private set; }

        public float Delay { get; private set; }
    }
}
