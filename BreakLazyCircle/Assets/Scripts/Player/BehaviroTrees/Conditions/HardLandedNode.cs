using BreakLazyCircle.CoreSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        var currentVelocityY = movement.CurrentVelocity.y;
        var hardLandThreshold = -blackboard.GetValue<PlayerData>("playerData").hardLandThreshold;
        Debug.Log($"HardLandedNode CheckCondition currentVelocityY: {currentVelocityY}, hardLandThreshold: {hardLandThreshold}");
        return currentVelocityY < hardLandThreshold;
    }
}
