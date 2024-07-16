using BreakLazyCircle.CoreSystem;

public class JumpNode : ExtActionNode
{
    private PlayerData playerData;
    private Core core;
    private Movement movement;
    private PlayerInputHandler inputHandler;

    protected override void OnStart()
    {
        base.OnStart();

        playerData ??= blackboard.GetValue<PlayerData>("playerData");
        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();

        movement.SetVelocityY(playerData.jumpVelocity);
    }
}
