using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class MoveNode : ActionNode
{
    private NodeProperty<PlayerData> playerData;

    protected override void OnStart() {
        context.animator.SetBool("move", true);
    }

    protected override void OnStop() {
        context.animator.SetBool("move", false);
    }

    protected override State OnUpdate() {
        
        return State.Success;
    }
}
