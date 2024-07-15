using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class CrouchMoveNode : ActionNode
{
    protected override void OnStart() {
        context.animator.SetBool("crouchMove", true);
    }

    protected override void OnStop() {
        context.animator.SetBool("crouchMove", false);
    }

    protected override State OnUpdate() {
        
        return State.Success;
    }
}
