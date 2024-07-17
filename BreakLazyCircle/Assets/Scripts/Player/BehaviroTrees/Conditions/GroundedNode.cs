using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

[System.Serializable]
public class GroundedNode : ConditionNode
{
    private Core core;
    private CollisionSenses collisionSenses;

    public NodeProperty<int> jumpLeft;

    protected override void OnStart()
    {
        base.OnStart();

        core ??= context.transform.GetComponentInChildren<Core>();
        collisionSenses ??= core.GetCoreComponent<CollisionSenses>();

        jumpLeft.Value = 2;
    }

    protected override bool CheckCondition() => collisionSenses.IsGround;
}
