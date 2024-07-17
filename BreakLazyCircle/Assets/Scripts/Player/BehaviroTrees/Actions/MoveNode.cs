using BreakLazyCircle.CoreSystem;

[System.Serializable]
public class MoveNode : ExtActionNode
{
    private PlayerData playerData;
    private Movement movement;
    private Core core;
    private PlayerInputHandler inputHandler;

    protected override void OnStart() {
        base.OnStart();

        playerData ??= blackboard.GetValue<PlayerData>("playerData");
        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override void OnStop() {
        
    }

    protected override State OnUpdate() {
        movement.FlipIfNeed(inputHandler.NormInputX);
        movement.SetVelocityX(playerData.movementVelocity * inputHandler.NormInputX);
        return State.Success;
    }
}
