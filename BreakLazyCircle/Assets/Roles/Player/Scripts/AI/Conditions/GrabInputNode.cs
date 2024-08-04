using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class GrabInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    protected override void OnStart()
    {
        Debug.Log("GrabInputNode OnStart");
        base.OnStart();

        inputHandler = context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition()
    {
        Debug.Log($"GrabInputNode CheckCondition: {inputHandler.GrabInput}");
        return inputHandler.GrabInput;
    }
}
