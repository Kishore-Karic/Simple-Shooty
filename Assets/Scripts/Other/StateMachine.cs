using UnityEngine;

namespace SimpleShooty.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        protected BaseState currentState;

        public void SetState(BaseState newState)
        {
            currentState = newState;

            if(currentState != null)
            {
                currentState.OnStateEnter();
            }
        }
    }
}