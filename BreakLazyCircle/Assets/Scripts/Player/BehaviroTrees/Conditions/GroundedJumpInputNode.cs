using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class GroundedJumpInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    private Core core;
    private CollisionSenses collisionSenses;

    protected override void OnStart()
    {
        base.OnStart();

        core ??= context.transform.GetComponentInChildren<Core>();
        collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition()
    {
        var jumpLeft = blackboard.GetValue<int>("amountOfJumpLeft");
        Debug.Log($"GroundedJumpInputNode jumpLeft: {jumpLeft}");
        return inputHandler.JumpInput && jumpLeft > 0 && !collisionSenses.IsCeiling;
    }
}
