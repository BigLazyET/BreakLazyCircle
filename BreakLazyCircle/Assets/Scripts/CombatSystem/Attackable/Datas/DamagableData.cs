using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "newDamagableData", menuName = "Data/Combat Data/Base Damagable Data")]
    public class DamagableData : ScriptableObject
    {
        [field: SerializeField] public int Health { get; set; }
        [field: SerializeField] public int CurrentHealth { get; set; }
        [field: SerializeField] public bool Invincible { get; set; }
    }
}
