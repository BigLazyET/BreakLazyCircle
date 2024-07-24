using UnityEngine;

namespace AbilitySystem
{
    [CreateAssetMenu(fileName = "dash", menuName ="Data/Ability/Dash")]
    public class DashAbility : Ability
    {
        public float dashVelocity;

        public override void Activate(GameObject parent)
        {
            var rb2d = parent.GetComponent<Rigidbody>();
            // TODO：只是打个比方，实际需要对应物体的inputhandler
            var inputHandler = parent.GetComponent<PlayerInputHandler>();
            rb2d.velocity = inputHandler.RawMovementInput.normalized * dashVelocity;
        }
    }
}
