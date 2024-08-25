using UnityEngine;

namespace AIShared
{
    /// <summary>
    /// 范围攻击
    /// </summary>
    [CreateAssetMenu(fileName ="newRangeAttackStateData", menuName ="Data/State Data/RangeAttack State")]
    public class D_RangeAttackState : ScriptableObject
    {
        public GameObject projectile;

        public float projectileSpeed = 12f;
        public float projectileTravelDistance;

        // TODO: projectile的伤害等数据不应该在这边设定，而因为在projectile本身对象中设定
        public float projectileDamage = 10f;
    }
}
