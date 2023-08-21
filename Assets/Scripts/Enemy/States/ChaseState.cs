namespace SimpleShooty.StateMachine.Enemy
{
    public class ChaseState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public ChaseState(EnemyStateMachine _enemyStateMachine) : base (_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.Animator.SetBool("Idle", true);
            enemyStateMachine.NavMeshAgent.isStopped = false;
        }

        public override void OnUpdate()
        {
            if (enemyStateMachine.IsPlayerInAttackRange())
            {
                stateMachine.SetState(enemyStateMachine.AttackState);
            }
            else if (enemyStateMachine.IsPlayerInChaseRange())
            {
                enemyStateMachine.NavMeshAgent.SetDestination(enemyStateMachine.GetPlayerTransform().position);
            }
            else
            {
                stateMachine.SetState(enemyStateMachine.IdleState);
            }
        }
    }
}