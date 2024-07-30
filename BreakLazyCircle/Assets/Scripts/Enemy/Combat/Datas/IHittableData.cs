using UnityEngine;

namespace BreakLazyCircle.Combat
{
    public interface IHittableData
    {
        HitType HitType { get; set; }

        bool DisableHitEffect { get; set; }

        Transform SpriteParent { get; set; }

        ParticleSystem CustomHitEffect { get; set; }

        AudioClip CustomHitSound { get; set; }

        bool HideWhenDead { get; set; }

        Material HitMaterial { get; set; }
    }
}
