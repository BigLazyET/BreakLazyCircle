using ProjectileSystem;
using System;
using UnityEngine;

namespace FalseKnight.Projectile
{
    [Serializable]
    public class FKShootWeapon
    {
        public AbstractProjectile projectilePrefab;
        public float horizontalForce = 5.0f;
        public float verticalForce = 4.0f;
    }
}
