using Combat.Enemy.AI;
using System;

namespace FalseKnight.AI
{
    [Serializable]
    public class FK_InAir : EnemyAction
    {
        private volatile bool isAnimationFinish;
        public string animationTriggerName;

        protected override void OnStart()
        {
            base.OnStart();

            animator.SetTrigger(animationTriggerName);
            isAnimationFinish = false;

            //_ = Task.Run(async() =>
            //{
            //    Debug.Log("Task started");

            //    while (true)
            //    {
            //        if (collisionSenses.IsGround)
            //        {
            //            Debug.Log($"FK_InAir Task is Ground");
            //            isAnimationFinish = true;
            //            break;
            //        }
            //        else
            //        {
            //            Debug.Log($"FK_InAir Task is InAir");
            //        }

            //        await Task.Delay(100);
            //    }
            //});
        }

        protected override State OnUpdate()
        {
            return collisionSenses.IsGround ? State.Success : State.Running;
        }

        protected override void OnStop()
        {
            base.OnStop();

            animator.ResetTrigger(animationTriggerName);
        }
    }
}
