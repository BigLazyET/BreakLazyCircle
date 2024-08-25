using AIShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakLazyCircle.Minions
{
    public class Patroler_PlayerDetectedState : PlayerDetectedState
    {
        private Patroler patroler;

        public Patroler_PlayerDetectedState(FiniteStateMachine fsm, Entity entity, string animBoolName, D_PlayerDetectedState stateData, Patroler patroler) : base(fsm, entity, animBoolName, stateData)
        {
            this.patroler = patroler;
        }

        public override void Init()
        {
            base.Init();
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


        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
