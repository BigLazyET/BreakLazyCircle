using CoreSystem;
using Combat;
using System;
using TheKiwiCoder;

namespace AIShared
{
    [Serializable]
    public class SetHealth : ActionNode
    {
        private Core core;
        private Damagable damagable;

        protected override void OnStart()
        {
            core ??= context.transform.GetComponentInChildren<Core>();
            damagable ??= core.GetCoreComponent<Damagable>();
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            // TODO: blackboard-health
            damagable.CurrentHealth = blackboard.GetValue<float>("health");
            return State.Success;
        }
    }
}
