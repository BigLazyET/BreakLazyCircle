using BreakLazyCircle.Util;
using Combat.Enemy.AI;
using DG.Tweening;
using System;
using UnityEngine;

namespace FalseKnight.AI
{
    [Serializable]
    public class FK_Jump : EnemyAction
    {
        public float horizontalForce = 5.0f;
        public float jumpForce = 10.0f;

        public float buildupTime;

        public string animationTriggerName;

        private bool isAnimationFinish;

        private Tween buildupTween;

        protected override void OnStart()
        {
            base.OnStart();
            isAnimationFinish = false;

            buildupTween = DOVirtual.DelayedCall(buildupTime, StartJump, false);
            animator.SetTrigger(animationTriggerName);
        }

        protected override State OnUpdate()
        {
            return isAnimationFinish ? State.Success : State.Running;
        }

        protected override void OnStop()
        {   
            base.OnStop();

            buildupTween?.Kill();
            isAnimationFinish = true;
        }

        private void StartJump()
        {
            var direction = player.transform.position.x < context.transform.position.x ? -1 : 1;
            movement.rb2D.AddForce(new Vector2(horizontalForce * direction, jumpForce), ForceMode2D.Impulse);

            isAnimationFinish = true;
        }
    }
}
