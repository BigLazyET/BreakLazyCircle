using UnityEngine;

namespace Combat
{
    public interface IHittableData
    {
        IHitTypeData[] HitTypes { get; set; }

        bool DisableHitEffect { get; set; }

        Transform SpriteTransform { get; set; }

        ParticleSystem CustomHitEffect { get; set; }

        AudioClip CustomHitSound { get; set; }

        bool HideWhenDead { get; set; }
    }
}
