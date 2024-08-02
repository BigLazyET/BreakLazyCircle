using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "newInflatDataData", menuName = "Data/Combat Data/Base Inflat Data")]
    public class HitTypeInflatData : ScriptableObject, IHitTypeInflatData
    {
        [field: SerializeField] public float XScale {  get; set; }
        [field: SerializeField] public float YScale {  get; set; }
        [field: SerializeField] public float ZScale {  get; set; }

        public HitType HitType => HitType.Inflate;

        [field: SerializeField] public bool IsRecoveryBack { get; private set; }

        [field: SerializeField] public float Duration { get; private set; }

        [field: SerializeField] public float Delay { get; private set; }
    }
}
