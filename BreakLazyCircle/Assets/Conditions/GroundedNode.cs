using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class GroundedNode : ConditionNode
{
    protected override bool CheckCondition() {
        return false;
    }
}
