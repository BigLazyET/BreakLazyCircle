using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class MoveNode : ExtActionNode
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
        movement.SetVelocity(playerData.movementVelocity, workspace);
        return State.Success;
    }
}
