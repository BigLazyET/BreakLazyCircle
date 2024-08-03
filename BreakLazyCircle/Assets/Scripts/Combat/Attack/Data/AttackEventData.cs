using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "newAttackEventData", menuName = "Data/Combat Attack Data/Attack Event Data")]
    public class AttackEventData : ScriptableObject
    {
        public ParticleSystem impactEffect;
        public float cameraShakeIntensity = 0.2f;
    }
}
