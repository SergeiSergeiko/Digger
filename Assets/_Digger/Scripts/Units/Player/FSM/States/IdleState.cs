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
        private readonly Player _player;
        private readonly GroundChecker _groundChecker;

        private bool _isGrounded;

        public IdleState(StateMachine<PlayerStates> fsm, PlayerInputActions input, GroundChecker groundChecker,
            Player player, Animator animator)
            : base(animator)
        {
            _fsm = fsm;
            _input = input;
            _player = player;
            _groundChecker = groundChecker;
        }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Idle);
        }

        public override void Update()
        {
            _isGrounded = _groundChecker.IsGrounded();
            
            if (_input.Player.Move.IsPressed())
                _fsm.SetState(PlayerStates.MOVE);

            if (_isGrounded == false)
                _fsm.SetState(PlayerStates.AIR);

            if (_input.Player.Jump.WasPressedThisFrame() && _isGrounded)
                _fsm.SetState(PlayerStates.JUMP);

            if (_isGrounded == false)
                _fsm.SetState(PlayerStates.AIR);

            if (_input.Player.Attack.IsPressed())
                _fsm.SetState(PlayerStates.ATTACK);

            if (_input.Player.GetDamage.WasPressedThisFrame())
                _player.TakeDamage(1);
        }

        public override void Exit() { }
    }
}