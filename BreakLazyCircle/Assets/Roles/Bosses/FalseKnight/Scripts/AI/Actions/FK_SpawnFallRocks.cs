using Combat.Enemy.AI;
using DG.Tweening;
using ProjectileSystem;
using UnityEngine;

namespace FalseKnight.AI
{
    [System.Serializable]
    public class FK_SpawnFallRocks : EnemyAction
    {
        private Collider2D spawnRocksAreaCollider;
        public AbstractProjectile rockPrefab;
        public int spawnRockCount = 4;
        public float spawnInterval = 0.3f;

        protected override void OnStart()
        {
            base.OnStart();

            spawnRocksAreaCollider ??= connector.spawnRocksAreaCollider;
        }

        protected override State OnUpdate()
        {
            var sequence = DOTween.Sequence();
            for (int i = 0; i < spawnRockCount; ++i)
            {
                sequence.AppendCallback(SpawnRock);
                sequence.AppendInterval(spawnInterval);
            }
            return State.Success;
        }

        private void SpawnRock()
        {
            var randomX = Random.Range(spawnRocksAreaCollider.bounds.min.x, spawnRocksAreaCollider.bounds.max.x);
            var rock = Object.Instantiate(rockPrefab, new Vector2(randomX, spawnRocksAreaCollider.bounds.min.y), Quaternion.identity);
            Debug.Log($"spawn falling rocks shooter: {context.gameObject.name}");
            rock.Shooter = context.gameObject;
            rock.SetForce(Vector2.zero);
        }
    }
}
