using UnityEngine;

namespace AIShared
{
    public class AnimationToStatemachine : MonoBehaviour
    {
        public AttackState attackState;

        private void TriggerAttack() => attackState.TriggerAttack();

        private void FinishAttack() => attackState.FinishAttack();
    }
}
