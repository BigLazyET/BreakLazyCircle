using Combat;
using System;
using UnityEngine;
using Pixelplacement;
using System.Collections;
using BreakLazyCircle.Util;
using System.Collections.Generic;

namespace BreakLazyCircle.CoreSystem
{
    public class Hittable : CoreComponent, IHittable
    {
        private SpriteRenderer spriteRenderer;
        private float baseScale;
        protected Color defaultColor = Color.white;
        private Material defaultMaterial;
        private IEnumerable<IHitTypeData> hitTypes;
        private Transform roleTransform;

        [field: SerializeField] public HittableData HittableData { get; private set; }

        public Transform spriteTransform;

        public event Action<Vector2, Vector2> OnHit;

        protected override void Awake()
        {
            base.Awake();

            roleTransform = core.Root.transform;
            baseScale = roleTransform.localScale.y;

            if (spriteTransform != null)
                spriteRenderer = spriteTransform.GetComponentInChildren<SpriteRenderer>();
            else
                spriteRenderer = roleTransform.GetComponentInChildren<SpriteRenderer>();
            defaultMaterial = spriteRenderer.material;

            hitTypes = HittableData.HitTypeDatas;
        }

        public void OnAttackHit(Vector2 position, Vector2 force)
        {
            OnHit?.Invoke(position, force);

            foreach (var hitType in hitTypes)
            {
                Hit(hitType);
            }

            if (!HittableData.DisableHitEffect)
            {
                if (HittableData.CustomHitEffect != null)
                    EffectManager.Instance.PlayParticleOneShot(HittableData.CustomHitEffect, position);

                CameraController.Instance.ShakeCamera(0.03f, 0.5f);
            }

            if (HittableData.CustomHitSound != null)
                SoundManager.Instance.PlaySoundAtLocation(HittableData.CustomHitSound, transform.position);
        }

        private void Hit(IHitTypeData hitTypeData)
        {
            if (hitTypeData.HitType == HitType.Inflate)
            {
                var inflatData = hitTypeData as HitTypeInflatData;
                Tween.LocalScale(roleTransform, new Vector3(roleTransform.localScale.x, baseScale, baseScale),
                    new Vector3(roleTransform.localScale.x * inflatData.XScale, baseScale * inflatData.YScale, baseScale * inflatData.ZScale),
                    hitTypeData.Duration, hitTypeData.Delay, Tween.EaseWobble);
            }
            else if (hitTypeData.HitType == HitType.Knockback)
            {
                var knockbackData = hitTypeData as HitTypeKnockbackData;
                Tween.Position(roleTransform, roleTransform.position,
                    roleTransform.position + knockbackData.KnockbackForce,
                    hitTypeData.Duration, hitTypeData.Delay, Tween.EaseWobble);
            }
            else if (hitTypeData.HitType == HitType.Color)
            {
                var colorData = hitTypeData as HitTypeColorData;
                spriteRenderer.material = colorData.HitMaterial;
                StartCoroutine(ResetMaterial(hitTypeData.Duration));
            }
        }

        private IEnumerator ResetMaterial(float duration)
        {
            yield return new WaitForSeconds(duration);
            spriteRenderer.material = defaultMaterial;
        }
    }
}
