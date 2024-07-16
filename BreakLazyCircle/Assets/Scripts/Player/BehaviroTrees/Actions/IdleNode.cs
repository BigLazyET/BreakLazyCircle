using UnityEngine;
using TheKiwiCoder;
using BreakLazyCircle.CoreSystem;

[System.Serializable]
public class IdleNode : ExtActionNode
{
    private Movement movement;

    protected override void OnStart() {
        base.OnStart();

        var core = context.transform.GetComponentInChildren<Core>();
        movement = core.GetCoreComponent<Movement>();
        movement.SetVelocityZero();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
