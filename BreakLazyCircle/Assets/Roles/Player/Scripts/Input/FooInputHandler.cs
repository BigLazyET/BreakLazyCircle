using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class FooInputHandler : MonoBehaviour
{
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Foo OnJump");
    }

    public void OnMove()
    {
        Debug.Log("Foo OnMove");
    }

    private void Update()
    {
        //Debug.Log("Foo Update");

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump button pressed");
            // 执行跳跃逻辑
        }
    }
}
