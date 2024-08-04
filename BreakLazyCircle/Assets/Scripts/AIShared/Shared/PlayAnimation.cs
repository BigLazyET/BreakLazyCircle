using DG.Tweening;
using System;
using TheKiwiCoder;
using UnityEngine;

namespace AIShared
{
    [Serializable]
    public class PlayAnimation : ActionNode
    {
        private Animator animator;
        private bool isAnimationFinish;

        public string animationTriggerName;
        public float duration;

        protected override void OnStart()
        {
            animator ??= context.transform.GetComponentInChildren<Animator>();
            Debug.Log($"PlayAnimation animationTriggerName: {animationTriggerName}");
            animator.SetTrigger(animationTriggerName);
            isAnimationFinish = false;

            DOVirtual.DelayedCall(duration, () =>
            {
                isAnimationFinish = true;
            }, false);
        }

        protected override void OnStop()
        {
            animator.ResetTrigger(animationTriggerName);
        }

        protected override State OnUpdate()
        {
            return isAnimationFinish ? State.Success : State.Running;
        }
    }
}
