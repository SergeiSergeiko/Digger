using UnityEngine;

namespace Assets._Digger.Scripts.Game.FSM
{
    public abstract class State
    {
        protected Animator Animator;

        protected State(Animator animator)
        {
            Animator = animator;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}