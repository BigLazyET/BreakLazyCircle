using BreakLazyCircle.CoreSystem;
using UnityEngine;

[System.Serializable]
public class CrouchMoveNode : ExtActionNode
{
    private PlayerData playerData;
    private Movement movement;
    private PlayerInputHandler inputHandler;

    private Vector2 workspace;

    protected override void OnStart() {
        base.OnStart();

        playerData = blackboard.GetValue<PlayerData>("playerData");
        var core = context.transform.GetComponentInChildren<Core>();
        movement = core.GetCoreComponent<Movement>();
        inputHandler = context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        movement.FlipIfNeed(inputHandler.NormInputX);
        workspace.Set(movement.FacingDirection, 0);
        movement.SetVelocity(playerData.crouchMovementVelocity, workspace);
        return State.Success;
    }
}