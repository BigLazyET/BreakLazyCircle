using Combat.Enemy.AI;
using FalseKnight.Projectile;
using System;
using System.Collections.Generic;

namespace FalseKnight.AI
{
    [Serializable]
    public class FK_Shoot : EnemyAction
    {
        public List<FKShootWeapon> fKShootWeapons;
        public bool shakeCamera;

        protected override State OnUpdate()
        {
            foreach (var fkShootWeapon in fKShootWeapons)
            {

            }

            return base.OnUpdate();
        }
    }
}
