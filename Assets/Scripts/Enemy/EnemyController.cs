using SimpleShooty.Player;
using SimpleShooty.StateMachine.Enemy;
using UnityEngine;

namespace SimpleShooty.Enemy
{
    public class EnemyController
    {
        private EnemyModel enemyModel;
        private EnemyView enemyView;
        private EnemyStateMachine enemyStateMachine;
        private Transform playerTransform;

        public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView, Transform spawnPoint)
        {
            enemyModel = _enemyModel;
            enemyView = GameObject.Instantiate(_enemyView, spawnPoint.position, Quaternion.identity);

            enemyView.SetEnemyController(this);
            enemyStateMachine = enemyView.EnemyStateMachine;
            enemyStateMachine.SetEnemyStateMachine(this, enemyView.NaveMeshAgent, enemyView.Animator);
            playerTransform = PlayerManager.Instance.PlayerTransform;
            enemyView.NaveMeshAgent.speed = enemyModel.MovementSpeed;
        }

        public bool IsPlayerInAttackRange()
        {
            if (playerTransform != null)
            {
                return Vector3.Distance(enemyView.transform.position, playerTransform.position) < enemyModel.AttackRange;
            }
            return false;
        }

        public bool IsPlayerInChaseRange()
        {
            if (playerTransform != null)
            {
                return Vector3.Distance(enemyView.transform.position, playerTransform.position) < enemyModel.ChaseRange;
            }
            return false;
        }
    }
}