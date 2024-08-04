using CoreSystem;
using System;
using TheKiwiCoder;

namespace AIShared
{
    [Serializable]
    public class EnemyCondition : ConditionNode
    {
        protected Core core;
        protected CollisionSenses collisionSenses;

        protected override void OnStart()
        {
            base.OnStart();

            core ??= context.transform.GetComponentInChildren<Core>();
            collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
        }

        protected override bool CheckCondition()
        {
            return true;
        }
    }
}
