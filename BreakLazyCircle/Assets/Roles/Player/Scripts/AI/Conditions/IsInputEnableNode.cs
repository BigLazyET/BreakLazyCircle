using System;
using TheKiwiCoder;

[System.Serializable]
public class IsInputEnableNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    protected override void OnStart()
    {
        base.OnStart();

        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition()
    {
        return inputHandler.IsInputEnable;
    }
}
