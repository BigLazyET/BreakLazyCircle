namespace Combat.Enemy.AI
{
    [System.Serializable]
    public class SetTrigger : EnemyAction
    {
        public string animationTriggerName;

        protected override State OnUpdate()
        {
            animator.SetTrigger(animationTriggerName);
            return State.Success;
        }
    }
}
