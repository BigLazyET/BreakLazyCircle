using UnityEngine;

namespace BreakLazyCircle.Combat
{
    [CreateAssetMenu(fileName = "newHittableData", menuName = "Data/Combat Data/Base Hittable Data")]
    public class HittableData : ScriptableObject, IHittableData
    {
        [SerializeField]
        private HitType hitType;
        [SerializeField]
        private bool disableHitEffect, hideWhenDead;
        [SerializeField]
        private ParticleSystem customHitEffect;
        [SerializeField]
        private Transform spriteParent;
        [SerializeField]
        private AudioClip customHitSound;
        [SerializeField]
        private Material hitMaterial;

        public HitType HitType { get => hitType; set => hitType = value; }

        public bool DisableHitEffect { get => disableHitEffect; set => disableHitEffect = value; }

        public Transform SpriteParent { get => spriteParent; set => spriteParent = value; }

        public ParticleSystem CustomHitEffect { get => customHitEffect; set => customHitEffect = value; }

        public AudioClip CustomHitSound { get => customHitSound; set => customHitSound = value; }

        public bool HideWhenDead { get => hideWhenDead; set => hideWhenDead = value; }

        public Material HitMaterial { get => hitMaterial; set => hitMaterial = value; }
    }
}
