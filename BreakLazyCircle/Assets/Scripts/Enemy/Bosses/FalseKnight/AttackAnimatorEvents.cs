using BreakLazyCircle.Util;
using Combat;
using Serializers;
using System.Collections.Generic;
using UnityEngine;

namespace BreakLazyCircle.Bosses
{
    /// <summary>
    /// 与Animation Event的强绑定
    /// 负责开启关闭攻击碰撞器collider，触发粒子效果，相机特效，声音等等
    /// 至于collider对应的攻击值，buff等等数值性数据可以绑定到collider上，这属于攻击击中
    /// 理解：攻击发出声音和效果 与 是否攻击击中物体无关；不管击没击中物体，我攻击的时候该有特效的有特效，该发声音的发声音
    /// </summary>
    public class AttackAnimatorEvents : MonoBehaviour
    {
        // TODO: 需要区分各种攻击collider
        // 攻击可以分很多种，包括但不限于：
        // 普通攻击：Normal Attack
        // 重攻击：Heavy Attack
        // 快速攻击：Quick Attack
        // 全图攻击：Area-wide Attack 或 Global Attack
        // 魔法攻击：Magic Attac
        public SerializableDictionary<string, AttackEventData> attackEventDataConf;

        private IDictionary<string, AttackEventData> attackEventDatas;

        private void Start()
        {
            attackEventDatas = attackEventDataConf.ToDictionary();
        }

        private void OnAttackStart(string attackType)
        {
            if (!attackEventDatas.ContainsKey(attackType)) return;
            var attackEventData = attackEventDatas[attackType];

            attackEventData.attackCollider.enabled = true;
            EffectManager.Instance.PlayParticleOneShot(attackEventData.impactEffect, attackEventData.impactTransform.position);
            CameraController.Instance.ShakeCamera(attackEventData.cameraShakeIntensity);
        }

        private void OnAttackEnd(string attackType)
        {
            if (!attackEventDatas.ContainsKey(attackType)) return;
            var attackEventData = attackEventDatas[attackType];

            attackEventData.attackCollider.enabled = false;
        }
    }
}
