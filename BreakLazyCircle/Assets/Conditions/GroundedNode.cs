using BreakLazyCircle.CoreSystem;
using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class GroundedNode : ConditionNode
{
    private CollisionSenses collisionSenses;

    protected override void OnStart()
    {
        base.OnStart();

        var core = context.transform.GetComponentInChildren<Core>();
        if (core == null)
        {
            Debug.Log("core is null");
        }
        collisionSenses = core.GetCoreComponent<CollisionSenses>();
    }

    protected override bool CheckCondition()
    {
        if (collisionSenses == null)
        {
            Debug.Log("collisionSenses is null");
        }
        else
        {
            Debug.Log($"collisionSenses IsGround: {collisionSenses.IsGround}");
        }
        
        return collisionSenses.IsGround;
    }
}
