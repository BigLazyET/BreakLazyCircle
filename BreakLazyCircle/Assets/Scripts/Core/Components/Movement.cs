using Unity.VisualScripting;
using UnityEngine;

namespace BreakLazyCircle.CoreSystem
{
    public class Movement : CoreComponent
    {
        public Rigidbody2D rb2D { get; private set; }

        // 运动状态
        public bool ReadOnlyVelocity { get; private set; }
        public int FacingDirection { get; private set; }

        // 运动数据
        public Vector2 CurrentVelocity { get; private set; }
        private Vector2 velocityWorkspace;

        // Gizmos
        private Vector2 gizmosWorkspace;

        protected override void Awake()
        {
            base.Awake();

            rb2D = core.Root.GetComponent<Rigidbody2D>();

            FacingDirection = 1;
            ReadOnlyVelocity = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CurrentVelocity = rb2D.velocity;
        }

        #region Public Methods
        public void SetVelocityZero()
        {
            velocityWorkspace = Vector2.zero;
            UpdateVelocity();
        }

        /// <summary>
        /// 设置运动速度，可用于WallJump等
        /// </summary>
        /// <param name="velocity">速度大小</param>
        /// <param name="angle">速度角度</param>
        /// <param name="direction">速度方向（往左或者往右，即±1）</param>
        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {
            angle.Normalize();
            velocityWorkspace = new Vector2(velocity * angle.x * direction, velocity * angle.y);
            UpdateVelocity();
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            velocityWorkspace = velocity * direction;
            UpdateVelocity();
        }

        public void SetVelocityX(float velocityX)
        {
            velocityWorkspace.Set(velocityX, CurrentVelocity.y);
            UpdateVelocity();
        }

        public void SetVelocityY(float velocityY)
        {
            velocityWorkspace.Set(CurrentVelocity.x, velocityY);
            UpdateVelocity();
        }

        public void FlipIfNeed(int xInput)
        {
            if (xInput == 0 || xInput == FacingDirection)
                return;
            Flip();
        }

        public void Flip()
        {
            FacingDirection *= -1;
            rb2D.transform.Rotate(0f, 180f, 0f);
        }

        public Vector2 FindRelativePoint(Vector2 offset)
        {
            offset.x *= FacingDirection;
            var relativePoint = transform.position + (Vector3)offset;
            return relativePoint;
        }
        #endregion

        #region Private Methods
        private void UpdateVelocity()
        {
            if (ReadOnlyVelocity)
                return;

            rb2D.velocity = velocityWorkspace;
            CurrentVelocity = velocityWorkspace;
        }
        #endregion
    }
}