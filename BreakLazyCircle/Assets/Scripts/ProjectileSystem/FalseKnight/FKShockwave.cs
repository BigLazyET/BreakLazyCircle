using BreakLazyCircle.Character;
using ProjectileSystem;
using UnityEngine;

namespace FalseKnight.Projectile
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"FKShockwave OnTriggerEnter2D gameobject name: {collision.gameObject.name}");

            var player = collision.GetComponent<Player>();
            if (player != null)
            {
                var force = this.force.normalized;
                // TODO: 数据ScriptableObject
                player.OnAttacked(collision.transform.position, force * 300f, damage);
                DestroyProjectile();
            }
        }
    }
}
