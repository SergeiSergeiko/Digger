using System;
using System.Collections.Generic;

namespace Assets._Digger.Scripts.Game.FSM
{
    public class StateMachine<T>
    {
        private Dictionary<Type, State> _states = new();

        public State CurrentState { get; private set; }

        public void SetState<S>() where S : State
        {
            var type = typeof(S);

            if (CurrentState != null && CurrentState?.GetType() == type)
                return;

            if (_states.TryGetValue(type, out var newState))
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentState.Enter();
            }
        }

        public void AddState(State state)
        {
            _states.Add(state.GetType(), state);
        }

        public void Update()
        {
            CurrentState?.Update();
        }
    }
}