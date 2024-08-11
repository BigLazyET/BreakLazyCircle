using UnityEngine;

namespace Combat.Enemy.AI
{
    public class IdleIcon : EnemyAction
    {
        public Sprite idleIcon;

        private SpriteRenderer spriteRenderer;

        protected override void OnStart()
        {
            base.OnStart();

            spriteRenderer = context.transform.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = idleIcon;
        }

        protected override State OnUpdate()
        {
            return State.Running;
        }
    }
}
