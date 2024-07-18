using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BreakLazyCircle.CoreSystem
{
    public class Core : MonoBehaviour
    {
        [field: SerializeField] public GameObject Root { get; private set; }

        private readonly IList<CoreComponent> CoreComponents = new List<CoreComponent>();

        #region Unity callbacks
        private void Awake()
        {
            Root = Root ?? transform.parent.gameObject;
        }

        private void Update()
        {
            LogicUpdate();
        }

        public void LogicUpdate()
        {
            foreach (var coreComponent in CoreComponents)
            {
                coreComponent.LogicUpdate();
            }
        }
        #endregion

        public void AddComponent(CoreComponent coreComponent)
        {
            if (CoreComponents.Contains(coreComponent))
                return;
            CoreComponents.Add(coreComponent);
        }

        public T GetCoreComponent<T>() where T : CoreComponent
        {
            var coreComponent = CoreComponents.OfType<T>().FirstOrDefault();
            if (coreComponent)
                return coreComponent;

            coreComponent = GetComponentInChildren<T>();
            if (coreComponent)
                return coreComponent;

            Debug.LogError($"{typeof(T)} not found on {Root?.name}");
            return null;
        }

        public T GetCoreComponent<T>(ref T value) where T : CoreComponent
        {
            value = GetCoreComponent<T>();
            return value;
        }
    }
}