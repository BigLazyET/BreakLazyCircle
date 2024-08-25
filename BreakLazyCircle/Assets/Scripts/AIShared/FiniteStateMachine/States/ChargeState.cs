using CoreSystem;
using UnityEngine;

namespace AIShared
{
    public class ChargeState : State
    {
        private Movement movement;
        private CollisionSenses collisionSenses;

        protected bool isChargeTimeOver;
        protected D_ChargeState stateData;
        protected bool isPlayerInMinAgroRange;
        protected bool isPlayerInCloseRangeAction;  // Close: 附近，表示距离近到可以做出一些动作，比如攻击
        protected bool isLedgeDetected;
        protected bool isWallDetected;

        public ChargeState(FiniteStateMachine fsm, Entity entity, string animBoolName, D_ChargeState stateData) : base(fsm, entity, animBoolName)
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

            isChargeTimeOver = false;
            movement.SetVelocityX(stateData.chargeSpeed * movement.FacingDirection);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            movement.SetVelocityX(stateData.chargeSpeed * movement.FacingDirection);
            isChargeTimeOver = Time.time > StartTime + stateData.chargeTime;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isPlayerInMinAgroRange = collisionSenses.IsPlayerInMinAgroRange;
            isLedgeDetected = collisionSenses.IsLedgeVertical;
            isWallDetected = collisionSenses.IsWallFront;
            isPlayerInCloseRangeAction = collisionSenses.IsPlayerInCloseRangeAction;
        }
    }
}
