using BreakLazyCircle.Bosses;
using Combat;
using Combat.Enemy.AI;
using CoreSystem;
using UnityEngine;

namespace FalseKnight.AI
{
    [System.Serializable]
    public class FK_SpawnMaggot : EnemyAction
    {
        public GameObject maggotPrefab;
        public Transform maggotTransform;
        public GameObject hazardCollider;

        private FKMaggot maggot;
        private Damagable maggot_Damagable;

        protected override void OnStart()
        {
            base.OnStart();

            // 构建Maggot
            maggot = Object.Instantiate(maggotPrefab, maggotTransform).GetComponent<FKMaggot>();
            maggot.transform.position = Vector3.zero;
            maggot_Damagable.Invincible = false;
            // disable假骑士Collider
            hazardCollider.SetActive(false);
        }

        protected override State OnUpdate()
        {
            if (maggot_Damagable.CurrentHealth > 0)
                return State.Running;
            maggot_Damagable.Invincible = true;
            hazardCollider.SetActive(true);
            return State.Success;
        }
    }
}
