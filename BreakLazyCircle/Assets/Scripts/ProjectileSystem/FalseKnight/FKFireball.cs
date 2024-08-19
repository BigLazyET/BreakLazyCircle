using BreakLazyCircle.Character;
using ProjectileSystem;
using System;
using UnityEngine;

namespace FalseKnight.Projectile
{
    public class FKFireball : AbstractProjectile
    {
        public override void SetForce(Vector2 force)
        {
            this.force = force;
            GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }

        private void Start()
        {
            Invoke(nameof(DestroyProjectile), 3f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"FKFireball OnTriggerEnter2D gameobject name: {collision.gameObject.name}");

            if (collision.gameObject == Shooter)
                return;

            var player = collision.GetComponent<Player>();
            if (player != null)
            {
                var force = this.force.normalized;
                // TODO: 数据ScriptableObject
                player.OnAttacked(collision.transform.position, force * 300f, damage);
            }

            DestroyProjectile();
        }
    }
}
