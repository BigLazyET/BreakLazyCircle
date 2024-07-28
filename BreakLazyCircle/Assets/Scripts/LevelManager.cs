using BreakLazyCircle.Util;
using UnityEngine;

namespace BreakLazyCircle
{
    public class LevelManager : MonoBehaviour
    {
        public Transform cameraBorders;

        private void Start()
        {
            // 放在Start方法中，是有原因的：
            // 1. 确保CameraController已经初始化，且启用
            // 2. Start优先于Update，在Start中设置CameraController的Borders
            // 从而可以让其的Update方法在需要使用的时候确认是有数据的，这点理解很关键
            // 所有组件的 Awake 方法首先被调用。
            // 接着所有组件 Start 方法被调用。
            // 最后，各个组件的Update 方法在每一帧中被调用。
            CameraController.Instance.SetCameraBorders(cameraBorders);
        }
    }
}
