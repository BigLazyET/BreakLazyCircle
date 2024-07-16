using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class CrouchInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    protected override void OnStart()
    {
        base.OnStart();

        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition()
    {
        Debug.Log($"inputHandler NormInputY: {inputHandler.NormInputY}");
        return inputHandler.NormInputY == -1;
    }
}
