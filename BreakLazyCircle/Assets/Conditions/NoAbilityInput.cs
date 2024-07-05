using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class NoAbilityInput : ConditionNode
{
    protected override bool CheckCondition() {
        return false;
    }
}
