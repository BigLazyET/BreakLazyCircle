using UnityEngine;

namespace BreakLazyCircle.CoreSystem
{
    public class CollisionSenses : CoreComponent
    {
        private Movement Movement => core.GetComponent<Movement>();

        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform wallCheck;
        [SerializeField] private Transform ceilingCheck;
        [SerializeField] private Transform ledgeHorizontalCheck;
        [SerializeField] private Transform ledgeVerticalCheck;

        [SerializeField] private float groundCheckRadius;
        [SerializeField] private float wallCheckDistance;

        [SerializeField] private LayerMask whatIsGround;

        // 并不是检测头顶碰撞，是检测什么情况你应该要蹲下去，很显然当碰撞点远小于你头顶的时候，你就应该蹲下去
        public bool IsCeiling => Physics2D.OverlapCircle(ceilingCheck.position, groundCheckRadius, whatIsGround);

        public bool IsGround => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        public bool IsWallFront => Physics2D.Raycast(wallCheck.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, whatIsGround);

        public RaycastHit2D WallFrontHitPoint => Physics2D.Raycast(wallCheck.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, whatIsGround);

        public bool IsWallBack => Physics2D.Raycast(wallCheck.position, Vector2.right * -Movement.FacingDirection, wallCheckDistance, whatIsGround);

        public bool IsLedgeHorizontal => Physics2D.Raycast(ledgeHorizontalCheck.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, whatIsGround);

        public bool IsLedgeVertical => Physics2D.Raycast(ledgeVerticalCheck.position, Vector2.down, wallCheckDistance, whatIsGround);

        public RaycastHit2D LedgeHitPoint(float xDistance, float offset)
        {
            var workspace = new Vector2((xDistance + offset) * Movement.FacingDirection, 0f);
            var point = Physics2D.Raycast(ledgeHorizontalCheck.position + (Vector3)workspace, Vector2.down, ledgeHorizontalCheck.position.y - wallCheck.position.y + offset, whatIsGround);
            return point;
        }

        private void OnDrawGizmosSelected()
        {
            
        }
    }
}