using Assets._Digger.Scripts.Units.Player.Animation;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.FSM.States
{
    public class DieState : UnitState
    {
        public DieState(Animator animator) : base(animator) { }

        public override void Enter()
        {
            Animator.Play(PlayerAnimationHashes.Die);
        }

        public override void Update() { }

        public override void Exit() { }
    }
}