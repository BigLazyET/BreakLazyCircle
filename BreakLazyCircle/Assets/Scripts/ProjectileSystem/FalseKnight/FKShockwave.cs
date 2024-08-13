using UnityEngine;

namespace ProjectileSystem
{
    public class FKShockwave : AbstractProjectile
    {
        public float speed;

        private Vector3 direction;
        private Vector3 velocity;

        public override void SetForce(Vector2 force)
        {
            this.force = force;
            direction = force.normalized;
        }

        private void Start()
        {
            Invoke(nameof(DestroyProjectile), 6.0f);
        }

        private void Update()
        {
            velocity += direction * speed * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
