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
    }
}
