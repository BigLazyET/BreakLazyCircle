using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class XInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    protected override void OnStart()
    {
        base.OnStart();

        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition() => inputHandler.NormInputX != 0;
}
