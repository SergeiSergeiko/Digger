using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(float direction)
        {
            _rigidbody2D.linearVelocity = new Vector2(direction * _speed, _rigidbody2D.linearVelocity.y);
        }

        public void Jump()
        {
            _rigidbody2D.AddForceY(_jumpForce, ForceMode2D.Impulse);
        }
    }
}