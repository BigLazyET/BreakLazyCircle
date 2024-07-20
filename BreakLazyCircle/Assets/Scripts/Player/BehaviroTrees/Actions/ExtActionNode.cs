using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class ExtActionNode : ActionNode
{
    public string animName;

    protected Core core;
    protected Movement movement;
    protected PlayerInputHandler inputHandler;


    protected override void OnStart()
    {
        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();

        var currentAnimName = blackboard.GetValue<string>("currentAnimName");
        if (string.IsNullOrWhiteSpace(currentAnimName))
        {
            blackboard.SetValue("currentAnimName", animName);
            context.animator.SetBool(animName, true);
        }
        else
        {
            var stateInfo = context.animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Land") && stateInfo.normalizedTime > 0f && stateInfo.normalizedTime < 1.0f)  // Land动画必须执行完成
            {
                movement.SetVelocityZero();
                blackboard.SetValue("inAirLastVelocity", Vector2.zero);
                inputHandler.IsInputEnable = false;
            }
            else
            {
                inputHandler.IsInputEnable = true;
                if (currentAnimName != animName)
                {
                    context.animator.SetBool(currentAnimName, false);
                    blackboard.SetValue("currentAnimName", animName);
                    context.animator.SetBool(animName, true);
                }
            }
        }
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return State.Success;
    }
}
