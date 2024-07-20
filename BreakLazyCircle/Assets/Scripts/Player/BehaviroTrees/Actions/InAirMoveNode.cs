using BreakLazyCircle.CoreSystem;
using System;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class InAirMoveNode : ExtActionNode
{
    public NodeProperty<PlayerData> playerData;

    protected override State OnUpdate()
    {
        movement.FlipIfNeed(inputHandler.NormInputX);
        movement.SetVelocityX(playerData.Value.inAirMovementVelocity * inputHandler.NormInputX);
        context.animator.SetFloat("xVelocity", Mathf.Abs(movement.CurrentVelocity.x));
        context.animator.SetFloat("yVelocity", movement.CurrentVelocity.y);
        blackboard.SetValue("inAirLastVelocity", movement.CurrentVelocity);
        return State.Success;
    }
}
