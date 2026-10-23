using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class IdleState : State
    {
        private readonly StateMachine<Player> _fsm;
        private readonly PlayerInputActions _input;
        private readonly Movement _movement;

        public IdleState(StateMachine<Player> fsm, PlayerInputActions input, Movement movement,
            Animator animator)
            : base(animator)
        {
            _fsm = fsm;
            _input = input;
            _movement = movement;
        }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Idle);
        }

        public override void Update()
        {
            if (_input.Player.Move.IsPressed())
                _fsm.SetState<MoveState>();

            if (_input.Player.Jump.IsPressed() || _movement.IsGrounded == false)
                _fsm.SetState<JumpState>();

            if (_input.Player.Attack.IsPressed())
                _fsm.SetState<AttackState>();

            if (_input.Player.Die.IsPressed())
                _fsm.SetState<DieState>();
        }

        public override void Exit() { }
    }
}