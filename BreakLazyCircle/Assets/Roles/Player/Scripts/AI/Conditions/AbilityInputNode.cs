using TheKiwiCoder;

[System.Serializable]
public class AbilityInputNode : ConditionNode
{
    private PlayerInputHandler inputHandler;

    protected override void OnStart()
    {
        base.OnStart();

        inputHandler = context.transform.GetComponent<PlayerInputHandler>();
    }

    protected override bool CheckCondition()
    {
        // TODO Other abilities input: dash | energy ball | magic | ...
        return inputHandler.JumpInput || inputHandler.AttackInput;
    }
}
