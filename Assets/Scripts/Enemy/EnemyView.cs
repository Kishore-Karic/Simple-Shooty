using SimpleShooty.Interface;
using SimpleShooty.Player;
using SimpleShooty.StateMachine.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace SimpleShooty.Enemy
{
    public class EnemyView : MonoBehaviour, IDamageable
    {
        [field: SerializeField] public EnemyStateMachine EnemyStateMachine { get; private set; }
        [field: SerializeField] public NavMeshAgent NaveMeshAgent { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field: SerializeField] public EnemyHealthUI EnemyHealthUI { get; private set; }

        private EnemyController enemyController;
        private bool IsSetToPlayer;

        public void SetEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }

        private void Update()
        {
            if (enemyController.IsEnemyInPlayerRange())
            {
                if (!PlayerManager.Instance.IsEnemyThere || PlayerManager.Instance.EnemyPriority < (int)enemyController.GetEnemyType())
                {
                    PlayerManager.Instance.SetEnemyInRange(gameObject, (int)enemyController.GetEnemyType());
                    IsSetToPlayer = true;
                }
            }
            else
            {
                if (IsSetToPlayer)
                {
                    PlayerManager.Instance.SetEnemyOutOfRange(gameObject);
                }
            }
        }

        public void Damage(int damage)
        {
            enemyController.TakeDamage(damage);
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}