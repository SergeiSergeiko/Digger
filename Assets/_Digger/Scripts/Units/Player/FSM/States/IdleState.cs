using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class IdleState : UnitState
    {
        private readonly StateMachine<PlayerStates> _fsm;
        private readonly PlayerInputActions _input;
        private readonly Movement _movement;

        public IdleState(StateMachine<PlayerStates> fsm, PlayerInputActions input, Movement movement,
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
                _fsm.SetState(PlayerStates.MOVE);

            if (_movement.IsGrounded == false)
                _fsm.SetState(PlayerStates.AIR);

            if (_input.Player.Jump.IsPressed() && _movement.IsGrounded)
                _fsm.SetState(PlayerStates.JUMP);

            if (_movement.IsGrounded == false)
                _fsm.SetState(PlayerStates.AIR);

            if (_input.Player.Attack.IsPressed())
                _fsm.SetState(PlayerStates.ATTACK);

            if (_input.Player.Die.IsPressed())
                _fsm.SetState(PlayerStates.DIE);
        }

        public override void Exit() { }
    }
}