using BreakLazyCircle.Util;
using Combat.Enemy.AI;
using DG.Tweening;
using System;
using UnityEngine;

namespace FalseKnight.AI
{
    [Serializable]
    public class Jump : EnemyAction
    {
        public float horizontalForce = 5.0f;
        public float jumpForce = 10.0f;

        public float buildupTime;
        public float jumpTime;

        public string animationTriggerName;
        public bool shakeCameraOnLanding;

        private bool hasLanded;

        private Tween buildupTween;
        private Tween jumpTween;

        protected override void OnStart()
        {
            base.OnStart();

            buildupTween = DOVirtual.DelayedCall(buildupTime, StartJump, false);
            animator.SetTrigger(animationTriggerName);
        }

        protected override State OnUpdate()
        {
            return hasLanded ? State.Success : State.Running;
        }

        protected override void OnStop()
        {   
            base.OnStop();

            buildupTween?.Kill();
            jumpTween?.Kill();
            hasLanded = false;
        }

        private void StartJump()
        {
            var direction = player.transform.position.x < context.transform.position.x ? -1 : 1;
            movement.rb2D.AddForce(new Vector2(horizontalForce * direction, jumpForce), ForceMode2D.Impulse);

            jumpTween = DOVirtual.DelayedCall(jumpTime, () =>
            {
                hasLanded = true;
                if (shakeCameraOnLanding)
                    CameraController.Instance.ShakeCamera(0.5f);
            });
        }
    }
}
