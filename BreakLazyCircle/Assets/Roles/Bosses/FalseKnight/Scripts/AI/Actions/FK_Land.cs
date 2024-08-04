using BreakLazyCircle.Util;
using Combat.Enemy.AI;
using DG.Tweening;
using System;

namespace FalseKnight.AI
{
    [Serializable]
    public class FK_Land : EnemyAction
    {
        private bool isAnimationFinish;

        public string animationTriggerName;
        public float duration = 1.0f;
        public float intensity = 0.5f;

        protected override void OnStart()
        {
            base.OnStart();

            animator.SetTrigger(animationTriggerName);
            isAnimationFinish = false;
            CameraController.Instance.ShakeCamera(intensity, duration);

            DOVirtual.DelayedCall(duration, () =>
            {
                isAnimationFinish = true;
            }, false);
        }

        protected override State OnUpdate()
        {
            return isAnimationFinish ? State.Success : State.Running;
        }

        protected override void OnStop()
        {
            animator.ResetTrigger(animationTriggerName);
        }
    }
}
