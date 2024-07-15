using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class IdleNode : ActionNode
{
    protected override void OnStart() {
        Debug.Log("IdleNode OnStart");
        if (!context.animator.GetBool("idle"))
        {
            Debug.Log("IdleNode OnStart Set idle to true");
            context.animator.SetBool("crouchIdle", false);
            context.animator.SetBool("idle", true);
        } 
    }

    protected override void OnStop() {
        Debug.Log("IdleNode OnStop");
    }

    protected override State OnUpdate() {
        Debug.Log("IdleNode OnUpdate");

        if (blackboard.keys.Count == 0)
        {
            Debug.Log("blackboard has not keys");
        }
        
        foreach (var key in blackboard.keys)
        {
            Debug.Log($"IdleNode blackboard key: {key}");
        }

        //var playerData = blackboard.Find<PlayerData>("playerData");
        //if (playerData != null || playerData.value != null)
        //{
        //    Debug.Log($"playerData maxHoldTime: {playerData.value.maxHoldTime}");
        //}

        return State.Success;
    }
}
