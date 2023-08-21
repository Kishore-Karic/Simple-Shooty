namespace SimpleShooty.StateMachine.Enemy
{
    public class DeadState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public DeadState(EnemyStateMachine _enemyStateMachine) : base (_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.Animator.SetBool("Idle", true);
            enemyStateMachine.NavMeshAgent.isStopped = true;
        }
    }
}