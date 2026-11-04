using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class JumpState : AirState
    {
        private readonly Movement _movement;
        private readonly StateMachine<PlayerStates> _fsm;

        public JumpState(StateMachine<PlayerStates> fsm, PlayerInputActions input, Movement movement,
            Animator animator) 
            : base(fsm, input, movement, animator)
        {
            _movement = movement;
            _fsm = fsm;
        }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Jump);

            _movement.NeedJump = true;
        }

        public override void Update()
        {
            base.Update();

            if (_movement.IsGrounded == false)
                _fsm.SetState(PlayerStates.AIR);
        }

        public override void Exit() { }
    }
}