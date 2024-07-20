using TheKiwiCoder;

[System.Serializable]
public class XInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    protected override void OnStart()
    {
        base.OnStart();

        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition()
    {
        var normInputX = inputHandler.NormInputX;

        return normInputX == -1 || normInputX == 1 && inputHandler.IsInputEnable();
    }
}
