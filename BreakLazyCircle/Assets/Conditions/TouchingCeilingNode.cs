using UnityEngine;
using TheKiwiCoder;
using BreakLazyCircle.CoreSystem;

[System.Serializable]
public class TouchingCeilingNode : ConditionNode
{
    private CollisionSenses collisionSenses;

    protected override void OnStart()
    {
        base.OnStart();

        var core = context.transform.GetComponentInChildren<Core>();
        if (core == null)
        {
            Debug.Log("core is null");
        }
        collisionSenses = core.GetCoreComponent<CollisionSenses>();
    }

    protected override bool CheckCondition() => collisionSenses.IsCeiling;
}
