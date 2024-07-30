//using BreakLazyCircle.Util;
//using System;
//using UnityEngine;

//namespace BreakLazyCircle.Combat
//{
//    public class HittableBase : IHittable
//    {
//        [field: SerializeField] public HittableData HittableData { get; private set; }

//        public event Action<Vector2, Vector2> OnHit;

//        private HitType hitType;

//        public virtual void Init()
//        {
//            hitType = HittableData.HitType;
//        }

//        public void OnAttackHit(Vector2 position, Vector2 force, int damage)
//        {
//            OnHit?.Invoke(position, force);

//            if (hitType == HitType.Inflate)
//            {
//                /*Tween.LocalScale(transform, new Vector3(baseScale, baseScale, baseScale),
//                    new Vector3(baseScale + 0.05f, baseScale + 0.05f, baseScale), 0.5f, 0, Tween.EaseWobble);*/
//                Tween.LocalScale(transform, new Vector3(transform.localScale.x, baseScale, baseScale),
//                    new Vector3(transform.localScale.x * 1.01f, baseScale + 0.05f, baseScale), 0.5f, 0,
//                    Tween.EaseWobble);
//            }
//            else if (hitType == HitType.Push)
//            {
//                // Push object quickly by a small amount and return to its original position
//                float hitAmount = 0.05f;
//                Tween.Position(transform, transform.position,
//                    transform.position + new Vector3(UnityEngine.Random.Range(-hitAmount, hitAmount),
//                        UnityEngine.Random.Range(-hitAmount, hitAmount), 0),
//                    0.5f, 0, Tween.EaseWobble);
//            }
//            else if (hitType == HitType.Color)
//            {
//                // Impact color flash
//                sprite.material = hitMaterial;
//                StartCoroutine(ResetMaterial(0.1f));
//            }

//            // Impact particle effect
//            if (!disableHitEffect)
//            {
//                if (customHitEffect != null)
//                    EffectManager.Instance.PlayOneShot(customHitEffect, position);
//                CameraController.Instance.ShakeCamera(0.03f, 0.5f);
//            }

//            if (customHitSound != null)
//                SoundManager.Instance.PlaySoundAtLocation(customHitSound, transform.position);
//        }
//    }
//}
