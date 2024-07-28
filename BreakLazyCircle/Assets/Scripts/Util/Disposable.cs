using UnityEngine;

namespace BreakLazyCircle.Util
{
    public class Disposable : MonoBehaviour
    {
        [Tooltip("The lifetime of gameobject what holds the component")]
        public float Lifetime = 1f;

        private void Start()
        {
            Destroy(gameObject, Lifetime);
        }
    }
}
