using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class WallGrabNode : ExtActionNode
{
    protected override void OnStart()
    {
        base.OnStart();

        var grabHoldPosition = blackboard.GetValue<Vector3>("grabHoldPosition");
        if (grabHoldPosition == Vector3.zero)
        {
            Debug.Log($"context.transform.position: {context.transform.position}");
            Debug.Log($"context.transform.name: {context.transform.name}");
            blackboard.SetValue("grabHoldPosition", context.transform.position);
        }
    }

    protected override State OnUpdate()
    {
        context.transform.position = blackboard.GetValue<Vector3>("grabHoldPosition");
        movement.SetVelocityZero();
        blackboard.SetValue("amountOfJumpLeft", 2);
        return State.Success;
    }
}
