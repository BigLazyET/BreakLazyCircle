using CoreSystem;
using Combat;
using System;
using TheKiwiCoder;

namespace AIShared
{
    [Serializable]
    public class IsHealthUnder : ConditionNode
    {
        private Core core;
        private Damagable damagable;

        protected override void OnStart()
        {
            base.OnStart();

            core ??= context.transform.GetComponentInChildren<Core>();
            damagable ??= core.GetCoreComponent<Damagable>();
        }

        protected override bool CheckCondition()
        {
            var healthThresold = blackboard.GetValue<float>("healthThresold");
            return damagable.CurrentHealth < healthThresold;
        }
    }
}
