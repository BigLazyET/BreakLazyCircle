using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 这是处理Input Action的一种方式：
/// 创建单独的一个InputHandler，包含各种Action触发的处理方法Unity Events
/// 再在Editor上绑定到Player Input组件（Behavior选择Invoke Unity Events）中的Events中
/// 
/// 还有两外一种方式Behavior选择Invoke csharp Events，那么你在创建Input Action资源的时候，在其Inspector面板上选中Generate C# Class
/// 会自动帮你一个类，其中包含Events方法
/// </summary>
public class PlayerInputHandler : MonoBehaviour
{
    // Movement Input Data
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    // Jump Input Data
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; } // 短按逻辑
    public float JumpInputStartTime { get; private set; }

    // Grab Input Data
    public bool GrabInput { get; private set; }

    // Attack Input Data
    public bool AttackInput { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f; // 长按逻辑

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("jump input in and get true");
            JumpInput = true;
            JumpInputStop = false;
            JumpInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            Debug.Log("jump input stop in and get true");
            JumpInputStop = true;
        }
    }

    public void ConsumeJumpInput() => JumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time > JumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GrabInput = true;
        }
        else if (context.canceled)
        {
            GrabInput = false;
        }
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
    }
}
