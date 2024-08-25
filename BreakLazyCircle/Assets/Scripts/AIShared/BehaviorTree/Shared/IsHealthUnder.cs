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

        public float healthThresold;

        protected override void OnStart()
        {
            base.OnStart();

            core ??= context.transform.GetComponentInChildren<Core>();
            damagable ??= core.GetCoreComponent<Damagable>();
        }

        protected override bool CheckCondition()
        {
            return damagable.CurrentHealth < healthThresold;
        }
    }
}
