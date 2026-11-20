using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class AirState : UnitState
    {
        private readonly StateMachine<PlayerStates> _fsm;
        private readonly PlayerInputActions _input;
        private readonly GroundChecker _groundChecker;
        private readonly Movement _movement;

        private bool _isGrounded;

        public AirState(StateMachine<PlayerStates> fsm, PlayerInputActions input, GroundChecker groundChecker,
            Movement movement, Animator animator)
            : base(animator)
        {
            _fsm = fsm;
            _input = input;
            _groundChecker = groundChecker;
            _movement = movement;
        }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Jump);
        }

        public override void Update()
        {
            _movement.Move(_input.Player.Move.ReadValue<float>());
            _isGrounded = _groundChecker.IsGrounded();

            if (_movement.IsMoving && _isGrounded)
                _fsm.SetState(PlayerStates.MOVE);

            if (_isGrounded)
                _fsm.SetState(PlayerStates.IDLE);

            if (_input.Player.Attack.IsPressed())
                _fsm.SetState(PlayerStates.ATTACK);

            if (_input.Player.Jump.WasPressedThisFrame())
                _fsm.SetState(PlayerStates.JUMP);
        }

        public override void Exit() { }
    }
}