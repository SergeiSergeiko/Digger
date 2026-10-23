using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class DieState : State
    {
        private readonly PlayerInputActions _input;
        private readonly StateMachine<Player> _fsm;

        public DieState(StateMachine<Player> fsm, PlayerInputActions input, Animator animator) 
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
                _fsm.SetState<MoveState>();
        }

        public override void Exit() { }
    }
}