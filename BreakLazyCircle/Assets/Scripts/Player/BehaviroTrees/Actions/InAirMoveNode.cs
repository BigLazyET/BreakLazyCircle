using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

[System.Serializable]
public class InAirMoveNode : ExtActionNode
{
    public NodeProperty<PlayerData> playerData;

    protected override State OnUpdate()
    {
        movement.FlipIfNeed(inputHandler.NormInputX);
        movement.SetVelocityX(playerData.Value.inAirMovementVelocity * inputHandler.NormInputX);
        context.animator.SetFloat("xVelocity", movement.CurrentVelocity.x);
        context.animator.SetFloat("yVelocity", movement.CurrentVelocity.y);
        return State.Success;
    }
}
