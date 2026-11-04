using Assets._Digger.Scripts.Game.FSM;
using UnityEngine;

namespace Assets._Digger.Scripts.Units
{
    public class UnitState : State
    {
        protected Animator Animator;

        public UnitState(Animator animator)
        {
            Animator = animator;
        }

        public override void Enter() { }

        public override void Exit() { }

        public override void Update() { }
    }
}