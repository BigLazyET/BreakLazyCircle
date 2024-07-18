using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;

[System.Serializable]
public class InAirNode : ExtActionNode
{
    private PlayerData playerData;
    private PlayerInputHandler inputHandler;
    private Core core;
    private Movement movement;

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
        var isJumpingStage = blackboard.GetValue<bool>("isJumpingStage");
        if (isJumpingStage)
        {
            if (inputHandler.JumpInputStop)
            {
                movement.SetVelocityY(movement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                blackboard.SetValue("isJumpingStage", false);
            }
            if (movement.CurrentVelocity.y <= 0f)
            {
                blackboard.SetValue("isJumpingStage", false);
            }
        }

        return base.OnUpdate();
    }
}
