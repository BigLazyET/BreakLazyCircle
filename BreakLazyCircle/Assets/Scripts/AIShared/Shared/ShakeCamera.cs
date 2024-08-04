using BreakLazyCircle.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using TheKiwiCoder;

namespace AIShared
{
    [Serializable]
    public class ShakeCamera : ActionNode
    {
        public float duration = 1.0f;
        public float intensity = 0.5f;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            CameraController.Instance.ShakeCamera(intensity, duration);
            return State.Success;
        }
    }
}
