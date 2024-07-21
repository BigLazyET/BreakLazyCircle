using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

[System.Serializable]
public class WallJumpInputNode : ConditionNode
{
    private Core core;
    private CollisionSenses collisionSenses;
    private PlayerInputHandler inputHandler;

    protected override void OnStart()
    {
        base.OnStart();

        core ??= context.transform.GetComponentInChildren<Core>();
        collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition()
    {
        var jumpLeft = blackboard.GetValue<int>("amountOfJumpLeft");
        return inputHandler.JumpInput && jumpLeft > 0 && !collisionSenses.IsCeiling;
    }
}
