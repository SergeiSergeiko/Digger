using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Flipper))]
    public class Movement : MonoBehaviour
    {
        [HideInInspector] public float Speed;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Flipper _fliper;

        private float _moveDirection;

        public bool IsMoving => _moveDirection != 0;

        private void FixedUpdate()
        {
            Move();
        }

        public void ResetState()
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
            _rigidbody2D.angularVelocity = 0f;
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
                new Vector2(_moveDirection * Speed, _rigidbody2D.linearVelocity.y);
        }
    }
}