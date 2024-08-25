using CoreSystem;
using UnityEngine;

namespace AIShared
{
    public class Entity : MonoBehaviour
    {
        private Transform entitySprite;

        protected Movement movement;
        protected CollisionSenses collision;

        public Core Core { get; private set; }
        public Animator animator {  get; private set; }
        public AnimationToStatemachine atsm {  get; private set; }

        public FiniteStateMachine fsm;

        public virtual void Awake()
        {
            entitySprite = transform.Find("Sprite");
            animator = entitySprite.GetComponent<Animator>();
            atsm = entitySprite.GetComponent<AnimationToStatemachine>();

            Core = GetComponentInChildren<Core>();
            movement = Core.GetCoreComponent<Movement>();
            collision = Core.GetCoreComponent<CollisionSenses>();

            fsm = new FiniteStateMachine();
        }

        public virtual void Update()
        {
            Core.LogicUpdate();
            fsm.CurrentState.LogicUpdate();
        }

        public virtual void FixedUpdate()
        {
            fsm.CurrentState.PhysicsUpdate();
        }
    }
}
