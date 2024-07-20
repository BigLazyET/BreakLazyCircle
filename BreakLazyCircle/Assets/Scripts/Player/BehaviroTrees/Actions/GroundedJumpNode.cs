using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class GroundedJumpNode : ExtActionNode
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
        movement.SetVelocityY(playerData.jumpVelocity);
        return State.Success;
    }
}
