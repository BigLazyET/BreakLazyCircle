using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "newAttackEventData", menuName = "Data/Combat Attack Data/Attack Event Data")]
    public class AttackEventData : ScriptableObject
    {
        public Collider2D attackCollider;
        public ParticleSystem impactEffect;
        public Transform impactTransform;
        public float cameraShakeIntensity = 0.2f;
    }
}
