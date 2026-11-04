using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class DieState : UnitState
    {
        private readonly PlayerInputActions _input;
        private readonly StateMachine<PlayerStates> _fsm;

        public DieState(StateMachine<PlayerStates> fsm, PlayerInputActions input, Animator animator) 
            : base(animator)
        {
            _input = input;
            _fsm = fsm;
        }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Die);
        }

        public override void Update()
        {
            if (_input.Player.Move.IsPressed())
                _fsm.SetState(PlayerStates.MOVE);
        }

        public override void Exit() { }
    }
}