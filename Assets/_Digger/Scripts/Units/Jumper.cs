using Assets._Digger.Scripts.Units.Player;
using System.Collections;
using UnityEngine;

namespace Assets._Digger.Scripts.Units
{
    public class Jumper : MonoBehaviour
    {
        [HideInInspector] public float JumpForce;
        [HideInInspector] public int CountMultiJump;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private GroundChecker _groundChecker;

        private Coroutine _coroutineResettingJumps;
        private int _currentCountJump;

        private void Start()
        {
            ResetJumpCount();
        }

        public void Jump()
        {
            if (CanJump() == false)
                return;

            _rigidbody2D.linearVelocityY = 0f;
            _rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

            _currentCountJump--;
            StartResettingJumpsCount();
        }

        private void StartResettingJumpsCount()
        {
            _coroutineResettingJumps ??= StartCoroutine(ResettingJumpsCount());
        }

        private IEnumerator ResettingJumpsCount()
        {
            bool isGrounded = false;

            while (isGrounded)
            {
                isGrounded = _groundChecker.IsGrounded();

                yield return null;
            }

            ResetJumpCount();
            _coroutineResettingJumps = null;
        }

        private void ResetJumpCount() => _currentCountJump = CountMultiJump;

        private bool CanJump() => _groundChecker.IsGrounded() && _currentCountJump > 0;
    }
}