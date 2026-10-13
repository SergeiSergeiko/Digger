using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._Digger.Scripts.Units.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private float _moveDirection;
        private bool _needJump = false;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();

            if (_needJump)
                TryJump();
        }

        public void Move(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<float>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            _needJump = true;
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
        }
    }
}