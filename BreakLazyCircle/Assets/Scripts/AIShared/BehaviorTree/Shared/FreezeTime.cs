using BreakLazyCircle;
using System;
using TheKiwiCoder;

namespace AIShared
{
    [Serializable]
    public class FreezeTime : ActionNode
    {
        public float freezeDuration;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            GameManager.Instance.FreezeTime(freezeDuration);
            return State.Success;
        }
    }
}
