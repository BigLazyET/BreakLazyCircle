using System;
using TheKiwiCoder;

namespace AIShared
{
    [Serializable]
    public class GoToNextStage : ActionNode
    {
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            // TODO: blackboard-currentStage
            var currentStage = blackboard.GetValue<int>("currentStage");
            blackboard.SetValue("currentStage", ++currentStage);
            return State.Success;
        }
    }
}
