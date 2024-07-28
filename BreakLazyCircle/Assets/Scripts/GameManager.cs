using System.Collections;
using UnityEngine;

namespace BreakLazyCircle
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private void Awake()
        {
            Instance ??= this;
        }

        /// <summary>
        /// 用于角色受伤时的效果
        /// </summary>
        /// <param name="duration"></param>
        public void FreezeTime(float duration)
        {
            Time.timeScale = 0.1f;
            StartCoroutine(UnFreezeTime(duration));
        }

        private IEnumerator UnFreezeTime(float duration)
        {
            yield return new WaitForSeconds(duration);
            Time.timeScale = 1f;
        }
    }
}
