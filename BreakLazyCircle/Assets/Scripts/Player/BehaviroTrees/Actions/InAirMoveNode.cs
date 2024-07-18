using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

[System.Serializable]
public class InAirMoveNode : ExtActionNode
{
    private Movement movement;
    private Core core;
    private PlayerInputHandler inputHandler;

    public NodeProperty<PlayerData> playerData;

    protected override void OnStart()
    {
        base.OnStart();

        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override State OnUpdate()
    {
        movement.FlipIfNeed(inputHandler.NormInputX);
        movement.SetVelocityX(playerData.Value.inAirMovementVelocity * inputHandler.NormInputX);
        context.animator.SetFloat("xVelocity", movement.CurrentVelocity.x);
        context.animator.SetFloat("yVelocity", movement.CurrentVelocity.y);
        return State.Success;
    }
}
