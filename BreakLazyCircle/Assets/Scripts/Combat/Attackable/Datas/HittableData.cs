using UnityEngine;

namespace Combat
{
    /// <summary>
    /// 被打击的自身的数据
    /// 包括限定自身可被打击的类型，打击时自身的sprite变化，粒子效果，声音等等
    /// </summary>
    [CreateAssetMenu(fileName = "newHittableData", menuName = "Data/Combat Data/Base Hittable Data")]
    public class HittableData : ScriptableObject, IHittableData
    {
        [field: SerializeField] public IHitTypeData[] HitTypes { get; set; }
        [field: SerializeField] public bool DisableHitEffect { get; set; }
        [field: SerializeField] public Transform SpriteTransform { get; set; }
        [field: SerializeField] public ParticleSystem CustomHitEffect { get; set; }
        [field: SerializeField] public AudioClip CustomHitSound { get; set; }
        [field: SerializeField] public bool HideWhenDead { get; set; }
    }
}
