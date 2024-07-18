using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

[System.Serializable]
public class GroundedNode : ConditionNode
{
    private Core core;
    private CollisionSenses collisionSenses;
    private PlayerInputHandler inputHandler;
    private Movement movement;
    private Player player;

    protected override void OnStart()
    {
        base.OnStart();

        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
        collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
        player ??= context.transform.GetComponent<Player>();
    }

    protected override bool CheckCondition()
    {
        var isGrounded = collisionSenses.IsGround;
        if (isGrounded)
        {
            //blackboard.SetValue("amountOfJumpLeft", 2);
            player.amountOfJumpLeft = 2;
            blackboard.SetValue("isJumpingStage", false);
            if (inputHandler.NormInputX == 0)
                movement.SetVelocityX(0);
        }
        return isGrounded;
    }
}
