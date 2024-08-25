using CoreSystem;
using UnityEngine;

namespace AIShared
{
    public class State
    {
        protected FiniteStateMachine fsm;
        protected Entity entity;
        protected string animBoolName;
        protected Core core;

        public float StartTime { get; protected set; }

        public State(FiniteStateMachine fsm, Entity entity, string animBoolName)
        {
            this.fsm = fsm;
            this.entity = entity;
            this.animBoolName = animBoolName;
            core = entity.Core;
        }

        public virtual void Init() { }

        public virtual void Enter()
        {
            Init();
            StartTime = Time.time;
            entity.animator.SetBool(animBoolName, true);
            DoChecks();
        }

        public virtual void Exit()
        {
            entity.animator.SetBool(animBoolName, false);
        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {

        }
    }
}
