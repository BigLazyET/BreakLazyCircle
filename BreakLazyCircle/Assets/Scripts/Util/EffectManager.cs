using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BreakLazyCircle.Util
{
    public class EffectManager : MonoBehaviour
    {
        public static EffectManager Instance;

        private void Awake()
        {
            Instance ??= this;
        }

        public void PlayParticleOneShot(ParticleSystem particleSystem, Vector3 position)
        {
            var effect = Instantiate(particleSystem, position, Quaternion.identity);
            effect.Play();

            var lifeTime = effect.main.startLifetime.constantMax + effect.main.duration;
            effect.gameObject.AddComponent<Disposable>().Lifetime = lifeTime;
        }

        public void PlaySpriteOneShot(SpriteRenderer spriteRenderer, Vector3 postion, bool flipX)
        {
            var effect = Instantiate(spriteRenderer, postion, Quaternion.identity);
            effect.flipX = flipX;
            effect.gameObject.AddComponent<Disposable>().Lifetime = 2f;
        }
    }
}
