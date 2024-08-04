using BreakLazyCircle.Util;
using DG.Tweening;
using System;
using TheKiwiCoder;
using UnityEngine;

namespace AIShared
{
    [Serializable]
    public class DestroySelf : ActionNode
    {
        public float bleedTime = 2.0f;
        public ParticleSystem bleedEffect;
        public ParticleSystem explodeEffect;
        private bool isDestroyed;

        protected override void OnStart()
        {
            EffectManager.Instance.PlayParticleOneShot(bleedEffect, context.transform.position);
            DOVirtual.DelayedCall(bleedTime, () =>
            {
                EffectManager.Instance.PlayParticleOneShot(explodeEffect, context.transform.position);
                CameraController.Instance.ShakeCamera(0.7f);
                isDestroyed = true;
                UnityEngine.Object.Destroy(context.gameObject);
            }, false);
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            return isDestroyed ? State.Success : State.Running;
        }
    }
}
