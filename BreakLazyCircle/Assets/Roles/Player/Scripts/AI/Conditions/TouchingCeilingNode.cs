using TheKiwiCoder;
using CoreSystem;

[System.Serializable]
public class TouchingCeilingNode : ConditionNode
{
    private CollisionSenses collisionSenses;

    protected override void OnStart()
    {
        base.OnStart();

        var core = context.transform.GetComponentInChildren<Core>();
        collisionSenses = core.GetCoreComponent<CollisionSenses>();
    }

    protected override bool CheckCondition() => collisionSenses.IsCeiling;
}
