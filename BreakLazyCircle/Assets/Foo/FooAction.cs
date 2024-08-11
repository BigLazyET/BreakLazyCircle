using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheKiwiCoder;
using UnityEngine;

namespace Assets.Foo
{
    public class FooAction : ActionNode
    {
        [field: SerializeField] public GameObject Transform { get; private set; }

        public GameObject maggotTransform;

        [SerializeField] private GameObject falseKnightTransform;

        public GameObject fooTransform { get; set; }

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            Debug.Log("Foo OnUpdate");
            return State.Success;
        }
    }
}
