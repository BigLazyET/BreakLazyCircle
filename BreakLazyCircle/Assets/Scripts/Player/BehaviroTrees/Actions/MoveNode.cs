using BreakLazyCircle.CoreSystem;

[System.Serializable]
public class MoveNode : ExtActionNode
{
    private PlayerData playerData;

    protected override void OnStart() {
        base.OnStart();

        playerData ??= blackboard.GetValue<PlayerData>("playerData");
    }

    protected override State OnUpdate() {
        movement.FlipIfNeed(inputHandler.NormInputX);
        movement.SetVelocityX(playerData.movementVelocity * inputHandler.NormInputX);
        return State.Success;
    }
}
