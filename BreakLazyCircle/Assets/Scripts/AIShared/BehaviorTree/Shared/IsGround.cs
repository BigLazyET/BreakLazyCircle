using System;

namespace AIShared
{
    [Serializable]
    public class IsGround : EnemyCondition
    {
        protected override bool CheckCondition()
        {
            return collisionSenses.IsGround;
        }
    }
}
