using AIShared;

namespace BreakLazyCircle.Minions
{
    public class Patroler_IdleState : IdleState
    {
        private Patroler patroler;

        public Patroler_IdleState(FiniteStateMachine fsm, Entity entity, string animBoolName, D_IdleState stateData, Patroler patroler) : base(fsm, entity, animBoolName, stateData)
        {
            this.patroler = patroler;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isPlayerInMinAgroRange)
                fsm.ChangeState(patroler.PlayerDetectedState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
