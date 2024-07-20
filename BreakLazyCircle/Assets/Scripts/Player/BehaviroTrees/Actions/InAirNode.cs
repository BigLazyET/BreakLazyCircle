using BreakLazyCircle.CoreSystem;
using UnityEngine;

[System.Serializable]
public class InAirNode : ExtActionNode
{
    private PlayerData playerData;

    protected override void OnStart()
    {
        base.OnStart();

        playerData ??= blackboard.GetValue<PlayerData>("playerData");
        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
    }

    protected override State OnUpdate()
    {
        context.animator.SetFloat("xVelocity", Mathf.Abs(movement.CurrentVelocity.x));
        context.animator.SetFloat("yVelocity", movement.CurrentVelocity.y);
        blackboard.SetValue("inAirLastVelocity", movement.CurrentVelocity);

        var isJumpingStage = blackboard.GetValue<bool>("isJumpingStage");
        if (isJumpingStage)
        {
            if (inputHandler.JumpInputStop)
            {
                movement.SetVelocityY(movement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                blackboard.SetValue("isJumpingStage", false);
            }
            if (movement.CurrentVelocity.y <= 0f)
            {
                blackboard.SetValue("isJumpingStage", false);
            }
        }

        return base.OnUpdate();
    }
}
