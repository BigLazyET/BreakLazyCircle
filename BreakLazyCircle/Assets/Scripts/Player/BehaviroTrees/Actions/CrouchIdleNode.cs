using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class CrouchIdleNode : ActionNode
{
    protected override void OnStart() {
        Debug.Log("CrouchIdleNode OnStart");
        if (!context.animator.GetBool("crouchIdle"))
        {
            Debug.Log("CrouchIdleNode OnStart Set crouchIdle to true");
            context.animator.SetBool("idle", false);
            context.animator.SetBool("crouchIdle", true);
        }
    }

    protected override void OnStop() {
        Debug.Log("CrouchIdleNode OnStop");
    }

    protected override State OnUpdate() {
        Debug.Log("CrouchIdleNode OnUpdate");

        
        return State.Success;
    }
}
