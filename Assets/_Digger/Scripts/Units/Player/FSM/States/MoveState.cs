using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class MoveState : UnitState
    {
        private readonly StateMachine<PlayerStates> _fsm;
        private readonly PlayerInputActions _input;
        private readonly Movement _movement;

        public MoveState(StateMachine<PlayerStates> fsm, PlayerInputActions input, Movement movement,
            Animator animator)
            : base(animator)
        {
            _fsm = fsm;
            _input = input;
            _movement = movement;
        }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Move);
        }

        public override void Update()
        {
            _movement.Move(_input.Player.Move.ReadValue<float>());

            if (_movement.IsMoving == false)
                _fsm.SetState(PlayerStates.IDLE);

            if (_input.Player.Jump.IsPressed() && _movement.IsGrounded)
                _fsm.SetState(PlayerStates.JUMP);

            if (_movement.IsGrounded == false)
                _fsm.SetState(PlayerStates.AIR);

            if (_input.Player.Attack.IsPressed())
                _fsm.SetState(PlayerStates.ATTACK);
        }

        public override void Exit()
        {
            _movement.Stop();
        }
    }
}