using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Flipper))]
    public class Movement : MonoBehaviour
    {
        [Header("Move")]
        [SerializeField] private float _speed;

        [Header("Jump")]
        [SerializeField] private float _jumpForce;

        [Space]
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private Flipper _fliper;

        public bool NeedJump = false;

        private float _moveDirection;

        public bool IsGrounded { get; private set; }
        public bool IsMoving => _moveDirection != 0;

        private void FixedUpdate()
        {
            Move();
            IsGrounded = _groundChecker.IsGrounded();

            if (NeedJump && IsGrounded)
                Jump();
        }

        public void Move(float moveDirection)
        {
            _moveDirection = moveDirection;
            _fliper.FlipX(moveDirection);
        }

        public void Stop()
        {
            float moveDirection = 0;

            Move(moveDirection);
        }

        private void Move()
        {
            _rigidbody2D.linearVelocity =
                new Vector2(_moveDirection * _speed, _rigidbody2D.linearVelocity.y);
        }

        private void Jump()
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            NeedJump = false;
        }
    }
}