using SimpleShooty.StateMachine.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace SimpleShooty.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [field: SerializeField] public EnemyStateMachine EnemyStateMachine { get; private set; }
        [field: SerializeField] public NavMeshAgent NaveMeshAgent { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

        private EnemyController enemyController;

        public void SetEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
    }
}