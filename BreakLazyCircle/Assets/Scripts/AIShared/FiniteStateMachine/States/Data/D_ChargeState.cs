using UnityEngine;

namespace AIShared
{
    /// <summary>
    /// 猛攻，冲锋
    /// </summary>
    [CreateAssetMenu(fileName = "newChargeStateData", menuName = "Data/State Data/Charge State")]
    public class D_ChargeState
    {
        public float chargeSpeed = 6f;

        public float chargeTime = 2f;
    }
}
