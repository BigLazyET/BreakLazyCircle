using UnityEngine;

namespace AIShared
{
    /// <summary>
    /// 用于标记Idle状态停留时间
    /// 超过这个时间需要自动转换到其他状态
    /// </summary>
    [CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/Idle State")]
    public class D_IdleState : ScriptableObject
    {
        public float minIdleTime = 1f;
        public float maxIdleTime = 2f;
    }
}
