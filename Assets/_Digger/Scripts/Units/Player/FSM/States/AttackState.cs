using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class AttackState : UnitState
    {
        private readonly StateMachine<PlayerStates> _fsm;

        public AttackState(StateMachine<PlayerStates> fsm, Movement movement, Animator animator) : base(animator)
        {
            _fsm = fsm;
        }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Attack);
        }

        public override void Update()
        {
            if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                _fsm.SetState(PlayerStates.IDLE);
        }

        public override void Exit() { }
    }
}