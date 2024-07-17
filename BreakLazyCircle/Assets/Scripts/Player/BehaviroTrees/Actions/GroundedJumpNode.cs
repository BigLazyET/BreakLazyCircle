using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class GroundedJumpNode : ExtActionNode
{
    private PlayerData playerData;
    private Core core;
    private Movement movement;
    private PlayerInputHandler inputHandler;

    public NodeProperty<bool> isJumpingStage;

    protected override void OnStart()
    {
        Debug.Log($"GroundedJumpNode OnStart");

        base.OnStart();

        playerData ??= blackboard.GetValue<PlayerData>("playerData");
        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();

        inputHandler.ConsumeJumpInput();
        var jumpLeft = blackboard.GetValue<int>("amountOfJumpLeft");
        blackboard.SetValue("amountOfJumpLeft", --jumpLeft);
        isJumpingStage.Value = true;
    }

    protected override State OnUpdate()
    {
        Debug.Log($"GroundedJumpNode OnUpdate");
        movement.SetVelocityY(playerData.jumpVelocity);
        return State.Success;
    }
}
