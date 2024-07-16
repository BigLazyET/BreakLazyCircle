using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class IdleNode : ExtActionNode
{
    protected override void OnStart() {
        base.OnStart();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
