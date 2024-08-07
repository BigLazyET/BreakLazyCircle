using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "newDamagableData", menuName = "Data/Combat Data/Base Damagable Data")]
    public class DamagableData : ScriptableObject
    {
        [field: SerializeField] public int Health { get; set; }
    }
}
