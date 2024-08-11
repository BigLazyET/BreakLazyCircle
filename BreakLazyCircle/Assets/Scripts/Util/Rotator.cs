using UnityEngine;

namespace Utils
{
    /// <summary>
    /// 旋转
    /// </summary>
    public class Rotator : MonoBehaviour
    {
        // TODO: 可对其进行扩展
        public float speed = 50f;
        public bool randomStartRotation;

        private void Update()
        {
            var localRotate = transform.localRotation.eulerAngles;
            localRotate.z += Time.deltaTime * speed;
            transform.localRotation = Quaternion.Euler(localRotate);
        }
    }
}
