using CoreSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIShared
{
    public class AttackState : State
    {
        private Movement movement;
        private CollisionSenses collisionSenses;
        private bool isAnimationFinished;

        protected bool isPlayerInMinAgroRange;

        public AttackState(FiniteStateMachine fsm, Entity entity, string animBoolName) : base(fsm, entity, animBoolName)
        {
        }

        public override void Init()
        {
            base.Init();

            movement ??= core.GetCoreComponent<Movement>();
            collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
        }

        public override void Enter()
        {
            base.Enter();

            entity.atsm.attackState = this; // 很重要！
            isAnimationFinished = false;
            movement.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            movement.SetVelocityX(0f);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isPlayerInMinAgroRange = collisionSenses.IsPlayerInMinAgroRange;
        }

        public virtual void TriggerAttack() { }

        public virtual void FinishAttack() => isAnimationFinished = true;
    }
}
