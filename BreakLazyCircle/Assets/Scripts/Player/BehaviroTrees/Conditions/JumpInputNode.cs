using TheKiwiCoder;

public class JumpInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    protected override void OnStart()
    {
        base.OnStart();

        inputHandler ??= context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition() => inputHandler.JumpInput && inputHandler.JumpCoolDown();
}
