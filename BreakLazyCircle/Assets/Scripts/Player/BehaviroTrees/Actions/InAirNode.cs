using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

[System.Serializable]
public class InAirNode : ExtActionNode
{
    private PlayerData playerData;
    private PlayerInputHandler inputHandler;
    private Core core;
    private Movement movement;

    public NodeProperty<bool> isJumpingStage;

    protected override void OnStart()
    {
        base.OnStart();

        playerData ??= blackboard.GetValue<PlayerData>("playerData");
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
    }

    protected override State OnUpdate()
    {
        if(isJumpingStage.Value)
        {
            if (inputHandler.JumpInputStop)
            {
                movement.SetVelocityY(movement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                isJumpingStage.Value = false;
            }
            if (movement.CurrentVelocity.y <= 0f)
            {
                isJumpingStage.Value = false;
            }
        }

        return base.OnUpdate();
    }
}
