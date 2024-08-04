using System;
using TheKiwiCoder;

namespace AIShared
{
    [Serializable]
    public class TurnAround : ActionNode
    {
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            var localScale = context.transform.localScale;
            localScale.x *= -1;
            context.transform.localScale = localScale;
            return State.Success;
        }
    }
}
