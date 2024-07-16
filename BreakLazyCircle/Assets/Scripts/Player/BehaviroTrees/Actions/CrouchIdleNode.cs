using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class CrouchIdleNode : ExtActionNode
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
