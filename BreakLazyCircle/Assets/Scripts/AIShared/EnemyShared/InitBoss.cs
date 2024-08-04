using System;
using UI;
using UnityEngine;

namespace Combat.Enemy.AI
{
    [Serializable]
    public class InitBoss : EnemyAction
    {
        protected override State OnUpdate()
        {
            // TODO: blackboard-bossName
            var bossName = blackboard.GetValue<string>("bossName");
            Debug.Log($"InitBoss bossName: {bossName}");
            GuiManager.Instance.ShowBossName(bossName);
            return State.Success;
        }
    }
}