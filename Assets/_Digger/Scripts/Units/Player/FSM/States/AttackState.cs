using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class AttackState : State
    {
        private readonly StateMachine<Player> _fsm;
        private readonly Movement _movement;

        public AttackState(StateMachine<Player> fsm, Movement movement, Animator animator) : base(animator)
        {
            _fsm = fsm;
            _movement = movement;
        }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Attack);
        }

        public override void Update()
        {
            if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                _fsm.SetState<IdleState>();
        }

        public override void Exit() { }
    }
}