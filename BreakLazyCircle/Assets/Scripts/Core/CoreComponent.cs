using UnityEngine;

namespace BreakLazyCircle.CoreSystem
{
    public class CoreComponent : MonoBehaviour
    {
        protected Core core;

        protected virtual void Awake()
        {
            core = transform.parent.GetComponent<Core>();
        }

        public virtual void LogicUpdate() { }
    }
}