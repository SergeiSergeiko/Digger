using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class JumpState : State
    {
        private readonly StateMachine<Player> _fsm;
        private readonly PlayerInputActions _input;
        private readonly Movement _movement;

        public JumpState(StateMachine<Player> fsm, PlayerInputActions input, Movement movement,
            Animator animator) 
            : base(animator)
        {
            _fsm = fsm;
            _input = input;
            _movement = movement;
        }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Jump);

            _movement.Jump();
        }

        public override void Update()
        {
            _movement.Move(_input.Player.Move.ReadValue<float>());

            if (_movement.IsMoving && _movement.IsGrounded)
                _fsm.SetState<MoveState>();

            if (_movement.IsGrounded)
                _fsm.SetState<IdleState>();

            if (_input.Player.Attack.IsPressed())
                _fsm.SetState<AttackState>();
        }

        public override void Exit() { }
    }
}