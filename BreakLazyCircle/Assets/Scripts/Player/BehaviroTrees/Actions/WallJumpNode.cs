[System.Serializable]
public class WallJumpNode : ExtActionNode
{
    private PlayerData playerData;

    protected override void OnStart()
    {
        base.OnStart();

        playerData ??= blackboard.GetValue<PlayerData>("playerData");

        inputHandler.ConsumeJumpInput();
        var jumpLeft = blackboard.GetValue<int>("amountOfJumpLeft");
        blackboard.SetValue("amountOfJumpLeft", --jumpLeft);
        blackboard.SetValue("isJumpingStage", true);
    }

    protected override State OnUpdate()
    {
        movement.SetVelocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, -movement.FacingDirection);

        return State.Success;
    }
}
