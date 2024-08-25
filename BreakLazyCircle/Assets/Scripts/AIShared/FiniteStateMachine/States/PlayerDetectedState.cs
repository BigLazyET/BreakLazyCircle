using CoreSystem;
using UnityEngine;

namespace AIShared
{
    public class PlayerDetectedState : State
    {
        private D_PlayerDetectedState stateData;
        private Movement movement;
        private CollisionSenses collisionSenses;

        protected bool isPlayerInMinAgroRange;
        protected bool isPlayerInMaxAgroRange;
        protected bool isPlayerInCloseRangeAction;
        protected bool isLedgeDetected;

        protected bool isPerformLongRangeAction;

        public PlayerDetectedState(FiniteStateMachine fsm, Entity entity, string animBoolName, D_PlayerDetectedState stateData) : base(fsm, entity, animBoolName)
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

            isPerformLongRangeAction = false;
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
            isPerformLongRangeAction = Time.time > StartTime + stateData.longRangeActionTime;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isPlayerInMaxAgroRange = collisionSenses.IsPlayerInMaxAgroRange;
            isPlayerInMaxAgroRange = collisionSenses.IsPlayerInMaxAgroRange;
            isPlayerInCloseRangeAction =  collisionSenses.IsPlayerInCloseRangeAction;
            isLedgeDetected = collisionSenses.IsLedgeVertical;
        }
    }
}
