using UnityEngine;

namespace AIShared
{
    [CreateAssetMenu(fileName = "newPlayerDetectedStateData", menuName = "Data/State Data/Player Detected State")]
    public class D_PlayerDetectedState : ScriptableObject
    {
        /// <summary>
        /// 当对象在ARGO范围内后，在范围内持续的时间
        /// </summary>
        public float longRangeActionTime = 1.5f;
    }
}
