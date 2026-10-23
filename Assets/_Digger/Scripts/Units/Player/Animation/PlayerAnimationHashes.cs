using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player.Animation
{
    public static class PlayerAnimationHashes
    {
        public static readonly int Idle = Animator.StringToHash("Idle");
        public static readonly int Move = Animator.StringToHash("Move");
        public static readonly int Jump = Animator.StringToHash("Jump");
        public static readonly int Attack = Animator.StringToHash("Attack");
        public static readonly int Die = Animator.StringToHash("Die");
    }
}