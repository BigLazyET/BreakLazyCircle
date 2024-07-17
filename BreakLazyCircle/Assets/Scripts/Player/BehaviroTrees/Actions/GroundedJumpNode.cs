using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

public class GroundedJumpNode : ExtActionNode
{
    private PlayerData playerData;
    private Core core;
    private Movement movement;
    private PlayerInputHandler inputHandler;

    public NodeProperty<int> jumpLeft;
    public NodeProperty<bool> isJumpingStage;

    protected override void OnStart()
    {
        base.OnStart();

        playerData ??= blackboard.GetValue<PlayerData>("playerData");
        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();

        inputHandler.ConsumeJumpInput();
        movement.SetVelocityY(playerData.jumpVelocity);
        jumpLeft.Value--;
        isJumpingStage.Value = true;
    }
}
