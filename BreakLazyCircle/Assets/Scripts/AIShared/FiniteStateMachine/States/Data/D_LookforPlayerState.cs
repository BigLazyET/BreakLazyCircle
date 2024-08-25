using UnityEngine;

namespace AIShared
{
    [CreateAssetMenu(fileName ="newLookforPlayerStateData", menuName ="Data/State Data/LookforPlayer State")]
    public class D_LookforPlayerState : ScriptableObject
    {
        public int amountOfTurns = 2;
        public float timeBetweenTurns = 0.75f;
    }
}
