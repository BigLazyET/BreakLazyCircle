using System.Collections.Generic;
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
    }
}