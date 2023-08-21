namespace SimpleShooty.StateMachine.Enemy
{
    public class IdleState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public IdleState(EnemyStateMachine _enemyStateMachine) : base (_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.Animator.SetBool("Idle", true);
            enemyStateMachine.NavMeshAgent.isStopped = true;
        }

        public override void OnUpdate()
        {
            if (enemyStateMachine.IsPlayerInChaseRange())
            {
                stateMachine.SetState(enemyStateMachine.ChaseState);
            }
        }
    }
}