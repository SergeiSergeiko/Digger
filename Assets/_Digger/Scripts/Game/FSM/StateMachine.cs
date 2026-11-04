using System.Collections.Generic;

namespace Assets._Digger.Scripts.Game.FSM
{
    public class StateMachine<T>
    {
        private Dictionary<string, State> _states = new();

        public string NameCurrentState { get; private set; }

        private State CurrentState;

        public void SetState(string name)
        {
            if (NameCurrentState == name)
                return;

            if (_states.TryGetValue(name, out var state))
            {
                CurrentState?.Exit();

                NameCurrentState = name;
                CurrentState = state;

                CurrentState.Enter();
            }
        }

        public void AddState(string name, State state)
        {
            _states.Add(name, state);
        }

        public void Update()
        {
            CurrentState?.Update();
        }
    }
}