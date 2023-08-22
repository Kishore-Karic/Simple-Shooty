namespace SimpleShooty.StateMachine
{
    public class BaseState
    {
        protected StateMachine stateMachine;

        public BaseState(StateMachine _stateMachine)
        {
            stateMachine = _stateMachine;
        }

        public virtual void OnStateEnter() { }
        public virtual void OnUpdate() { }
    }
}