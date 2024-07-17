using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class InAirJumpInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    public NodeProperty<int> jumpLeft;

    protected override void OnStart()
    {
        base.OnStart();

        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition()
    {
        var jumpLeft = blackboard.GetValue<int>("amountOfJumpLeft");
        Debug.Log($"InAirJumpInputNode jumpLeft: {jumpLeft}");
        return inputHandler.JumpInput && jumpLeft > 0;
    }
}