using Combat;
using UnityEngine;

namespace BreakLazyCircle.Bosses
{
    [System.Serializable]
    public class AttackEventConf
    {
        public AttackEventData attackEventData;

        public Collider2D attackCollider;

        public Transform impactTransform;
    }
}
