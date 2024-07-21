using BreakLazyCircle.CoreSystem;
using System;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class GroundedNode : ConditionNode
{
    private Core core;
    private CollisionSenses collisionSenses;
    private PlayerInputHandler inputHandler;
    private Movement movement;

    protected override void OnStart()
    {
        base.OnStart();

        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
        collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition()
    {
        var isGrounded = collisionSenses.IsGround;
        if (isGrounded)
        {
            if (MathF.Abs(movement.CurrentVelocity.y) < 0.01f)
            {
                blackboard.SetValue("amountOfJumpLeft", 2);
            }
            if (inputHandler.NormInputX == 0)
                movement.SetVelocityX(0f);
            blackboard.SetValue("grabHoldPosition", Vector3.zero);
        }
        return isGrounded;
    }
}
