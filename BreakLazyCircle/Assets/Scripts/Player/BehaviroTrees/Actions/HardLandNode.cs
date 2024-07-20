using BreakLazyCircle.CoreSystem;
using UnityEngine;

[System.Serializable]
public class HardLandNode : ExtActionNode
{
    protected override void OnStart()
    {
        Debug.Log("HardLandNode OnStart");
        base.OnStart();

        movement.SetVelocityZero();
        inputHandler.DisableInput();
    }
}

