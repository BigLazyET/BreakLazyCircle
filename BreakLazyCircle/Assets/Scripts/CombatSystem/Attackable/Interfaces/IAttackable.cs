using UnityEngine;

namespace Combat
{
    /// <summary>
    /// 这个用于所有角色（玩家，敌人，包括一些静态的物体）继承
    /// 主要用作标记作用，标记实现IAttackable的角色皆为可被攻击的
    /// 当被检测到攻击的时候，可以直接通过IAttackable来检索到所有的物体
    /// Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, attackableLayer);
    /// IAttackable attackable = collider.GetComponent<IAttackable>();
    /// </summary>
    public interface IAttackable
    {
        /// <summary>
        /// 自身被攻击
        /// </summary>
        /// <param name="hitPosition"></param>
        /// <param name="force"></param>
        /// <param name="damage"></param>
        void OnAttacked(Vector2 hitPosition, Vector2 force, float damage);
    }
}
