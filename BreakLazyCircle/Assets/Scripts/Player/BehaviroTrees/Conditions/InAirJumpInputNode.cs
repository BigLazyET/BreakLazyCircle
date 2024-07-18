using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class InAirJumpInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;
    private Player player;

    protected override void OnStart()
    {
        base.OnStart();

        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
        player ??= context.transform.GetComponent<Player>();
    }

    protected override bool CheckCondition()
    {
        var jumpLeft = player.amountOfJumpLeft; //blackboard.GetValue<int>("amountOfJumpLeft");
        Debug.Log($"InAirJumpInputNode jumpLeft: {jumpLeft}");
        return inputHandler.JumpInput && jumpLeft > 0;
    }
}