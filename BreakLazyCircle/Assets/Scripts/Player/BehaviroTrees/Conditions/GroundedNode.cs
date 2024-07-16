using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

[System.Serializable]
public class GroundedNode : ConditionNode
{
    private CollisionSenses collisionSenses;

    protected override void OnStart()
    {
        base.OnStart();

        var core = context.transform.GetComponentInChildren<Core>();
        collisionSenses = core.GetCoreComponent<CollisionSenses>();
    }

    protected override bool CheckCondition() => collisionSenses.IsGround;
}