using BreakLazyCircle.Util;
using System;
using UnityEngine;

namespace ProjectileSystem
{
    public abstract class AbstractProjectile : MonoBehaviour
    {
        public float damage;
        public ParticleSystem particleEffec;
        public AudioClip splatterSound; // 飞溅
        public event Action<AbstractProjectile> OnProjectileDestroyed;

        protected Vector2 force;

        public GameObject Shooter { get; set; }

        public abstract void SetForce(Vector2 force);

        protected void DestroyProjectile()
        {
            OnProjectileDestroyed?.Invoke(this);

            if (splatterSound != null)
                SoundManager.Instance.PlaySoundAtLocation(splatterSound, transform.position, 0.75f);

            EffectManager.Instance.PlayParticleOneShot(particleEffec, transform.position);

            Destroy(gameObject);
        }
    }
}
