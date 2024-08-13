using BreakLazyCircle.Bosses;
using BreakLazyCircle.Character;
using CoreSystem;
using System;
using TheKiwiCoder;
using UnityEngine;

namespace Combat.Enemy.AI
{
    [Serializable]
    public class EnemyAction : ActionNode
    {
        protected Core core;
        protected Movement movement;
        protected CollisionSenses collisionSenses;
        protected Player player;
        protected Animator animator;
        protected FKConnector connector;

        protected override void OnStart()
        {
            core ??= context.transform.GetComponentInChildren<Core>();
            movement ??= core.GetCoreComponent<Movement>();
            collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
            player ??= Player.Instance;
            animator ??= context.transform.GetComponentInChildren<Animator>();
            connector ??= context.transform.GetComponent<FKConnector>();
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            return State.Success;
        }
    }
}
