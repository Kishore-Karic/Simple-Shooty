using SimpleShooty.Enemy;
using SimpleShooty.Player;
using UnityEngine;
using UnityEngine.AI;

namespace SimpleShooty.StateMachine.Enemy
{
    public class EnemyStateMachine : StateMachine
    {
        public NavMeshAgent NavMeshAgent { get; private set; }
        public Animator Animator { get; private set; }

        public IdleState IdleState { get; private set; }
        public ChaseState ChaseState { get; private set; }
        public AttackState AttackState { get; private set; }
        public DeadState DeadState { get; private set; }

        private EnemyController enemyController;

        private void InitializeStates()
        {
            IdleState = new IdleState(this);
            ChaseState = new ChaseState(this);
            AttackState = new AttackState(this);
            DeadState = new DeadState(this);
        }

        private void Update()
        {
            if (currentState != null)
            {
                currentState.OnUpdate();
            }
        }

        public void SetEnemyStateMachine(EnemyController _enemyController, NavMeshAgent _agent, Animator _animator)
        {
            enemyController = _enemyController;
            NavMeshAgent = _agent;
            Animator = _animator;

            InitializeStates();

            SetState(IdleState);
        }

        public bool IsPlayerInAttackRange()
        {
            return enemyController.IsPlayerInAttackRange();
        }

        public bool IsPlayerInChaseRange()
        {
            return enemyController.IsPlayerInChaseRange();
        }

        public Transform GetPlayerTransform()
        {
            return PlayerManager.Instance.PlayerTransform;
        }

        public void PlayerDead()
        {
            PlayerManager.Instance.PlayerDead();
        }

        public void EnemyDead()
        {
            SetState(DeadState);
        }
    }
}