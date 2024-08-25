using UnityEngine;

namespace AIShared
{
    /// <summary>
    /// 近战攻击数据
    /// </summary>
    [CreateAssetMenu(fileName ="newMeleeAttackStateData", menuName ="Data/State Data/MeleeAttack State")]
    public class D_MeleeAttackState : ScriptableObject
    {
        public float attackRadius = 0.5f;
        public float attackDamage = 10f;
        public float poiseDamage;

        // TODO: 设计问题：knockback到底作为被攻击对象自有的数据，还是攻击对象的数据，进行攻击时传递？
        public float knockbackStrength = 10f;
        public Vector2 knockbackAngle = Vector2.one;
    }
}
