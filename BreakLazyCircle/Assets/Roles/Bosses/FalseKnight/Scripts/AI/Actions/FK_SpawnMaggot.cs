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

        // TODO: 当前的Behaviour Tree不支持Transform和GameObject，因为他们不是Serializale的
        // 如何更新？
        private Transform maggotTransform;
        private GameObject hazardCollider;

        private FKMaggot maggot;
        private Damagable maggot_Damagable;

        protected override void OnStart()
        {
            base.OnStart();

            maggotTransform ??= context.transform.Find("Maggot Transform");
            hazardCollider ??= context.transform.Find("Hazard Collider").gameObject;
            maggot_Damagable ??= core.GetCoreComponent<Damagable>();

            // 构建Maggot
            maggot = Object.Instantiate(maggotPrefab, maggotTransform).GetComponent<FKMaggot>();
            maggot.transform.localPosition = Vector3.zero;
            maggot_Damagable.Invincible = true;
            // disable假骑士Collider
            hazardCollider.SetActive(false);
        }

        protected override State OnUpdate()
        {
            if (maggot_Damagable.CurrentHealth > 0)
                return State.Running;
            maggot_Damagable.Invincible = false;
            hazardCollider.SetActive(true);
            return State.Success;
        }
    }
}
