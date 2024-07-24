using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AbilitySystem
{
    public class AbilityHolder : MonoBehaviour
    {
        public Ability ability;

        private float cooldownTime;
        private float activeTime;

        private AbilityState state = AbilityState.Ready;

        private void Update()
        {
            switch (state)
            {
                case AbilityState.Cooldown:
                    cooldownTime -= Time.deltaTime;
                    if (cooldownTime < 0)
                    {
                        state = AbilityState.Ready;
                    }
                    break;
                case AbilityState.Active:
                    activeTime -= Time.deltaTime;
                    if (activeTime < 0)
                    {
                        state = AbilityState.Cooldown;
                        cooldownTime = ability.cooldownTime;
                    }
                    break;
                case AbilityState.Ready:
                    // 判断某个条件或者按键按下符合条件
                    state = AbilityState.Active;
                    activeTime = ability.activeTime;
                    break;
                default:
                    break;
            }
        }
    }
}
