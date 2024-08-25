using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIShared
{
    public class MoveState : State
    {
        public MoveState(FiniteStateMachine fsm, Entity entity, string animBoolName) : base(fsm, entity, animBoolName)
        {
        }
    }
}
