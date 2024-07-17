using TheKiwiCoder;

public class InAirJumpInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    public NodeProperty<int> jumpLeft;

    protected override void OnStart()
    {
        base.OnStart();

        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition() => inputHandler.JumpInput && jumpLeft.Value > 0;
}