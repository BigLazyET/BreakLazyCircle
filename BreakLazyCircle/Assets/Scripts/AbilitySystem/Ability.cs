using UnityEngine;

namespace AbilitySystem
{
    public class Ability : ScriptableObject
    {
        public new string name;
        public float cooldownTime;
        public float activeTime;

        public virtual void Activate(GameObject parent) { }
        public virtual void BeginCooldown(GameObject parent) {}
        // TODO：添加其他的方法
    }
}
