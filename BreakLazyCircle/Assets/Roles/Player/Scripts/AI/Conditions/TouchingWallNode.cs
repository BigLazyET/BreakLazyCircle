using CoreSystem;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class TouchingWallNode : ConditionNode
{
    private Core core;
    private Movement movement;
    private CollisionSenses collisionSenses;

    protected override void OnStart()
    {
        base.OnStart();

        core ??= context.transform.GetComponentInChildren<Core>();
        movement ??= core.GetCoreComponent<Movement>();
        collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
    }

    protected override bool CheckCondition()
    {
        return collisionSenses.IsWallFront;
    }
}