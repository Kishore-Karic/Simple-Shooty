using SimpleShooty.Enum;
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

            playerTransform = PlayerManager.Instance.PlayerTransform;
            enemyView.SetEnemyController(this);
            enemyStateMachine = enemyView.EnemyStateMachine;
            enemyStateMachine.SetEnemyStateMachine(this, enemyView.NaveMeshAgent, enemyView.Animator);
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

        public bool IsEnemyInPlayerRange()
        {
            if (playerTransform != null)
            {
                return Vector3.Distance(enemyView.transform.position, playerTransform.position) < enemyModel.PlayerRange;
            }
            return false;
        }

        public EnemyType GetEnemyType()
        {
            return enemyModel.EnemyType;
        }

        public void TakeDamage(int damage)
        {
            enemyModel.SetCurrentHealth(enemyModel.CurrentHealth - damage);
            enemyView.EnemyHealthUI.SetHealthUI(enemyModel.TotalHealth - enemyModel.CurrentHealth);

            if(enemyModel.CurrentHealth <= enemyModel.Zero)
            {
                PlayerManager.Instance.EnemyDestroyed(enemyView.gameObject);
                enemyView.DestroyObject();
            }
        }
    }
}