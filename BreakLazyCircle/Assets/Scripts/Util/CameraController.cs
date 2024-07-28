using BreakLazyCircle.Character;
using UnityEngine;

namespace BreakLazyCircle.Util
{
    /// <summary>
    /// 不利用Cinemachine，直接用原生Camera组件实现跟随和FOV Border限制
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        public static CameraController Instance;

        public Transform cameraTarget;
        public float scrollSpeed = 8.0f;
        public float verticalOffset = 3.0f;

        private Transform cameraBorders;
        private Vector3 borderMin;
        private Vector3 borderMax;

        public Player player;

        public bool isFlowPlayer = true;

        private Vector2 targetPosition;

        private void Awake()
        {
            Instance ??= this;
        }

        private void Update()
        {
            if (!isFlowPlayer)
                return;

            var direction = player.transform.position - cameraTarget.position;

            // 决定Camera横向运动的X
            if (direction.x > 0)
                targetPosition.x = Mathf.Min(player.transform.position.x, borderMax.x - 9.0f);
            else
                targetPosition.x = Mathf.Max(player.transform.position.x, borderMin.x + 9.0f);

            // 移动Camera
            MoveSmoothToTarget();
        }

        public void SetCameraBorders(Transform cameraBorders)
        {
            this.cameraBorders = cameraBorders;

            var minX = cameraBorders.GetChild(3).position.x;
            var maxX = cameraBorders.GetChild(1).position.x;
            var minY = cameraBorders.GetChild(2).position.x;
            var maxY = cameraBorders.GetChild(0).position.x;
            borderMax = new Vector2(maxX, maxY);
            borderMin = new Vector2(minX, minY);

            targetPosition.x =
               Mathf.Max(Mathf.Min(player.transform.position.x, borderMax.x - 9.0f), borderMin.x + 9.0f);
            targetPosition.y = Mathf.Min(Mathf.Max(player.transform.position.y + verticalOffset, borderMin.y + 10.0f),
                borderMax.y - 5.0f);

            MoveQuickToTarget();
        }

        public void MoveQuickToTarget()
        {
            cameraTarget.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }

        public void MoveSmoothToTarget()
        {
            cameraTarget.position = new Vector3(
                Mathf.SmoothStep(cameraTarget.position.x, targetPosition.x, Time.deltaTime * scrollSpeed),
                Mathf.SmoothStep(cameraTarget.position.y, targetPosition.y, Time.deltaTime * scrollSpeed),
                cameraTarget.position.z);
        }
    }
}
