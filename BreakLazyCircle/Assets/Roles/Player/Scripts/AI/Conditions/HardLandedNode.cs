using CoreSystem;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class HardLandedNode : ConditionNode
{
    private Core core;
    private Movement movement;

    protected override void OnStart()
    {
        base.OnStart();

        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
    }

    protected override bool CheckCondition()
    {
        var inAirLastVelocity = blackboard.GetValue<Vector2>("inAirLastVelocity");
        var hardLandThreshold = -blackboard.GetValue<PlayerData>("playerData").hardLandThreshold;
        return inAirLastVelocity.y < hardLandThreshold;
    }
}
