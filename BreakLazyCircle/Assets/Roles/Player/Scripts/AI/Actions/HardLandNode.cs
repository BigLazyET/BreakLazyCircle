using CoreSystem;
using UnityEngine;

[System.Serializable]
public class HardLandNode : ExtActionNode
{
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
            if (currentAnimName != animName)
            {
                movement.SetVelocityZero();
                blackboard.SetValue("inAirLastVelocity", Vector2.zero);
                inputHandler.IsInputEnable = false;
                context.animator.SetBool(currentAnimName, false);
                blackboard.SetValue("currentAnimName", animName);
                context.animator.SetBool(animName, true);
            }
        }
    }
}

