using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

[System.Serializable]
public class GroundedNode : ConditionNode
{
    private Core core;
    private CollisionSenses collisionSenses;

    protected override void OnStart()
    {
        base.OnStart();

        core ??= context.transform.GetComponentInChildren<Core>();
        collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
    }

    protected override bool CheckCondition()
    {
        var isGrounded = collisionSenses.IsGround;
        if (isGrounded)
        {
            blackboard.SetValue("amountOfJumpLeft", 2);
            //blackboard.SetValue("isJumpingStage", false);
        }
        return isGrounded;
    }
}
