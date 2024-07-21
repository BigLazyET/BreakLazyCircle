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
        blackboard.SetValue("grabHoldPosition", Vector3.zero);

        // 跳跃手感
        // 根据上升和下降阶段设置：1. Rigidbody.gravityScale 2. Rigidbody.velocity
        if (movement.CurrentVelocity.y > 0) // 上升阶段
        {
            // 短按长按跳跃高度不一样
            if (inputHandler.JumpInputStop)
            {
                movement.SetVelocityY(movement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
            }
        }
        else  // 下降阶段
        {

        }

        return State.Success;
    }
}
