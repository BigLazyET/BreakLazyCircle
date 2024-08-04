using UnityEngine;

namespace FalseKnight.Data
{
    [CreateAssetMenu(fileName = "newFKData", menuName = "Data/Enemy Data/False Knight Data")]
    public class FalseKnightData : ScriptableObject
    {
        [Header("Move State")]
        public float movementVelocity = 15f;
        public float inAirMovementVelocity = 5f;

        [Header("Jump State")]
        public float jumpVelocity = 15f;

        [Header("Stun State")]
        public float stunTime = 2f;
    }
}
