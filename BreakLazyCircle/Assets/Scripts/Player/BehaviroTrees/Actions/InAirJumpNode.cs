using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class InAirJumpNode : ExtActionNode
{
    private PlayerData playerData;
    private Core core;
    private Movement movement;
    private PlayerInputHandler inputHandler;
    private Player player;

    protected override void OnStart()
    {
        base.OnStart();

        playerData ??= blackboard.GetValue<PlayerData>("playerData");
        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
        player ??= context.transform.GetComponent<Player>();

        inputHandler.ConsumeJumpInput();
        //var jumpLeft = blackboard.GetValue<int>("amountOfJumpLeft");
        //blackboard.SetValue("amountOfJumpLeft", --jumpLeft);
        player.amountOfJumpLeft -= 1;
        blackboard.SetValue("isJumpingStage", true);
    }

    protected override State OnUpdate()
    {
        movement.SetVelocityY(playerData.jumpVelocity);
        return State.Success;
    }
}
