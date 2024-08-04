using System;

namespace Combat.Enemy.AI
{
    [Serializable]
    public class FacePalyer : EnemyAction
    {
        protected override State OnUpdate()
        {
            var localScale = context.transform.localScale;
            var isPlayerOnRight = player.transform.position.x > context.transform.position.x;
            localScale.x = isPlayerOnRight ? 1 : -1;

            context.transform.localScale = localScale;

            return State.Success;
        }
    }
}
