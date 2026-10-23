using System;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [Header("Move")]
        [SerializeField] private float _speed;

        [Header("Jump")]
        [SerializeField] private float _jumpForce;

        [Space]
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private GroundChecker _groundChecker;

        private float _moveDirection;
        private bool _needJump = false;

        public bool IsGrounded { get; private set; }
        public bool IsMoving => _moveDirection != 0;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
            IsGrounded = _groundChecker.IsGrounded();

            if (_needJump && IsGrounded)
                TryJump();
        }

        public void Move(float moveDirection)
        {
            _moveDirection = moveDirection;
            FlipX(moveDirection);
        }

        public void Jump()
        {
            _needJump = true;
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

        private void TryJump()
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            _needJump = false;
            IsGrounded = false;
        }

        private void FlipX(float moveDirection)
        {
            Vector3 scale = gameObject.transform.localScale;

            if (moveDirection > 0)
                scale.x = Math.Abs(scale.x);
            else
                if (moveDirection < 0)
                    if (scale.x > 0)
                        scale.x *= -1;

            gameObject.transform.localScale = scale;
        }
    }
}