using CoreSystem;
using UnityEngine;

namespace AIShared
{
    public class DodgeState : State
    {
        private Movement movement;
        private CollisionSenses collisionSenses;

        protected D_DodgeState stateData;
        protected bool isDodgeOver;

        protected bool isPlayerInCloseRangeAction;
        protected bool isGround;
        protected bool isPlayerInMaxAgroRange;

        public DodgeState(FiniteStateMachine fsm, Entity entity, string animBoolName, D_DodgeState stateData) : base(fsm, entity, animBoolName)
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

            isDodgeOver = false;
            movement.SetVelocity(stateData.dodgeSpeed, stateData.dodgeAngle, -movement.FacingDirection);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            isDodgeOver = Time.time > StartTime + stateData.dodgeTime;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isPlayerInCloseRangeAction = collisionSenses.IsPlayerInCloseRangeAction;
            isGround = collisionSenses.IsGround;
            isPlayerInMaxAgroRange = collisionSenses.IsPlayerInMaxAgroRange;
        }
    }
}
