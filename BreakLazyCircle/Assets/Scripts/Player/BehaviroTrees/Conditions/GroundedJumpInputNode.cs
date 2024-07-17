using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

public class GroundedJumpInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    private Core core;
    private CollisionSenses collisionSenses;

    public NodeProperty<int> jumpLeft;

    protected override void OnStart()
    {
        base.OnStart();

        core ??= context.transform.GetComponentInChildren<Core>();
        collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition() => inputHandler.JumpInput && jumpLeft.Value > 0 && !collisionSenses.IsCeiling;
}
