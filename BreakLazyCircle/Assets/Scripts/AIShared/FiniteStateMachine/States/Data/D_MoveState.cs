using UnityEngine;

namespace AIShared
{
    [CreateAssetMenu(fileName = "newMoveState", menuName = "Data/State Data/Move State")]
    public class D_MoveState : ScriptableObject
    {
        public float moveSpeed = 3f;
    }
}
