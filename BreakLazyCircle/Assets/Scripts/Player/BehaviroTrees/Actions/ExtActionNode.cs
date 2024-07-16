using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class ExtActionNode : ActionNode
{
    public string animName;

    protected override void OnStart()
    {
        Debug.Log("ExtActionNode OnStart");
        var currentAnimName = blackboard.GetValue<string>("currentAnimName");
        if (!string.IsNullOrWhiteSpace(currentAnimName) && currentAnimName != animName)
        {
            context.animator.SetBool(currentAnimName, false);
        }
        blackboard.SetValue("currentAnimName", animName);
        context.animator.SetBool(animName, true);
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        return State.Success;
    }
}
