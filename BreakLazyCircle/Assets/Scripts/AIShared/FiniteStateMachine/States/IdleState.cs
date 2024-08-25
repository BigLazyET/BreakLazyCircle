using CoreSystem;
using UnityEngine;

namespace AIShared
{
    public class IdleState : State
    {
        private Movement movement;
        private CollisionSenses collisionSenses;

        private D_IdleState stateData;
        private float idleTime;
        private bool isIdleTimeOver;
        private bool isFlipAfterIdle;

        protected bool isPlayerInMinAgroRange;

        public IdleState(FiniteStateMachine fsm, Entity entity, string animBoolName, D_IdleState stateData) : base(fsm, entity, animBoolName)
        {
            this.stateData = stateData;
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

            movement.SetVelocityX(0f);
            idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
            isIdleTimeOver = false;
            
        }

        public override void Exit()
        {
            base.Exit();

            if (isFlipAfterIdle)
                movement.Flip();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            movement.SetVelocityX(0f);
            isIdleTimeOver = Time.time > StartTime + idleTime;
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

        public void SetFlipAfterIdle(bool flip) => isFlipAfterIdle = flip;
    }
}
