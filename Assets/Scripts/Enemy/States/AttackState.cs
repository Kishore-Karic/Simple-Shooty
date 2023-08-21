namespace SimpleShooty.StateMachine.Enemy
{
    public class AttackState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public AttackState(EnemyStateMachine _enemyStateMachine) : base (_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.PlayerDead();
            enemyStateMachine.NavMeshAgent.isStopped = true;
            enemyStateMachine.Animator.SetBool("Idle", true);
        }
    }
}