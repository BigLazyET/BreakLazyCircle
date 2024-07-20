using BreakLazyCircle.CoreSystem;
using UnityEngine;

[System.Serializable]
public class HardLandNode : ExtActionNode
{
    protected override void OnStart()
    {
        base.OnStart();

        movement.SetVelocityZero();
        blackboard.SetValue("inAirLastVelocity", Vector2.zero);
        inputHandler.DisableInput();
    }
}

