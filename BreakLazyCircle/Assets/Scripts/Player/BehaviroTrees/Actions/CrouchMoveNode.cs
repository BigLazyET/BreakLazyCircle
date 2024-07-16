using BreakLazyCircle.CoreSystem;
using UnityEngine;

[System.Serializable]
public class CrouchMoveNode : ExtActionNode
{
    private PlayerData playerData;
    private Core core;
    private Movement movement;
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
        movement.SetVelocityX(playerData.crouchMovementVelocity * inputHandler.NormInputX);
        return State.Success;
    }
}
