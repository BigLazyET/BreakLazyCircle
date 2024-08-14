using BreakLazyCircle.Util;
using TheKiwiCoder;
using UnityEngine;

namespace AIShared
{
    [System.Serializable]
    public class PlayParticle : ActionNode
    {
        public ParticleSystem particle;

        protected override void OnStart()
        {
            
        }

        protected override State OnUpdate()
        {
            EffectManager.Instance.PlayParticleOneShot(particle, context.transform.position);
            return State.Success;
        }

        protected override void OnStop()
        {
            
        }
    }
}
