using System;
using UnityEngine;

namespace Combat
{
    [Serializable]
    public class HitTypeDataWrapper
    {
        [SerializeField] private ScriptableObject hitTypeData;

        public IHitTypeData HitTypeData => hitTypeData as IHitTypeData;
    }
}
