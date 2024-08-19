using BreakLazyCircle.Util;
using Combat.Enemy.AI;
using FalseKnight.Projectile;
using System.Collections.Generic;
using UnityEngine;

namespace FalseKnight.AI
{
    [System.Serializable]
    public class FK_Shoot : EnemyAction
    {
        public List<FKShootWeapon> fKShootWeapons;
        public bool shakeCamera;

        private Transform weaponTransform;

        protected override void OnStart()
        {
            base.OnStart();

            weaponTransform ??= context.transform.Find("Weapon Transform");
        }

        protected override State OnUpdate()
        {
            foreach (var fkShootWeapon in fKShootWeapons)
            {
                var projectile = Object.Instantiate(fkShootWeapon.projectilePrefab, weaponTransform.position, Quaternion.identity);
                Debug.Log($"shockwave shooter: {context.gameObject.name}");
                projectile.Shooter = context.gameObject;    // TODO: 到底哪个gameobject

                var force = new Vector2(fkShootWeapon.horizontalForce * context.transform.localScale.x, fkShootWeapon.verticalForce);
                projectile.SetForce(force);

                if (shakeCamera)
                    CameraController.Instance.ShakeCamera(0.5f);
            }
            if (shakeCamera)
                CameraController.Instance.ShakeCamera(0.5f);

            return State.Success;
        }
    }
}
