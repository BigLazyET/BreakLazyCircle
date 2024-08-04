using System;
using UnityEngine;

namespace Combat
{
    public interface IHittable
    {
        /// <summary>
        /// 被打击的自身的数据
        /// 包括限定自身可被打击的类型，打击时自身的sprite变化，粒子效果，声音等等
        /// </summary>
        HittableData HittableData { get; }

        /// <summary>
        /// 打击事件
        /// </summary>
        event Action<Vector2, Vector2> OnHit;

        /// <summary>
        /// 被打击后的方法
        /// </summary>
        /// <param name="position"></param>
        /// <param name="force"></param>
        void OnAttackHit(Vector2 position, Vector2 force);
    }
}
