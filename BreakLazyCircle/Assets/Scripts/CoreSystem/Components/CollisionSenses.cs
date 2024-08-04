using UnityEngine;

namespace CoreSystem
{
    public class CollisionSenses : CoreComponent
    {
        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform wallCheck;
        [SerializeField] private Transform ceilingCheck;
        [SerializeField] private Transform ledgeHorizontalCheck;
        [SerializeField] private Transform ledgeVerticalCheck;

        [SerializeField] private float groundCheckRadius;
        [SerializeField] private float wallCheckDistance;

        [SerializeField] private LayerMask whatIsGround;

        private Movement Movement => core.GetCoreComponent<Movement>();

        private Vector2 gizmosWorkspace;

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
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            Gizmos.DrawWireSphere(ceilingCheck.position, groundCheckRadius); 

            Gizmos.color = Color.red;
            gizmosWorkspace.Set(wallCheckDistance, 0);  // 不全面，应该要考虑 Movement.FacingDirection
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)gizmosWorkspace);
        }
    }
}