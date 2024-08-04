using BreakLazyCircle;
using System;
using TheKiwiCoder;

namespace AIShared
{
    [Serializable]
    public class FreezeTime : ActionNode
    {
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            // TODO: blackboard-freezeTime
            var freezeTime = blackboard.GetValue<float>("freezeTime");
            GameManager.Instance.FreezeTime(freezeTime);
            return State.Success;
        }
    }
}
