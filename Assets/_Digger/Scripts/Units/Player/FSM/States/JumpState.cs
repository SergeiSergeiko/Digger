using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class JumpState : AirState
    {
        private readonly Jumper _jumper;
        private readonly StateMachine<PlayerStates> _fsm;
        private readonly GroundChecker _groundChecker;

        public JumpState(StateMachine<PlayerStates> fsm, PlayerInputActions input, GroundChecker groundChecker,
            Movement movement, Jumper jumper, Animator animator) 
            : base(fsm, input, groundChecker, movement, animator)
        {
            _jumper = jumper;
            _fsm = fsm;
            _groundChecker = groundChecker;
        }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Jump);

            _jumper.Jump();
        }

        public override void Update()
        {
            base.Update();

            if (_groundChecker.IsGrounded() == false)
                _fsm.SetState(PlayerStates.AIR);
        }

        public override void Exit() { }
    }
}