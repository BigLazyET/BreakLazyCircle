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

        public float health;

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
            damagable.CurrentHealth = health;
            return State.Success;
        }
    }
}
