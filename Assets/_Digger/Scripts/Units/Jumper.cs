using Assets._Digger.Scripts.Units.Player;
using UnityEngine;

namespace Assets._Digger.Scripts.Units
{
    public class Jumper : MonoBehaviour
    {
        [HideInInspector] public float JumpForce;
        [HideInInspector] public int NumberDoubleJump;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private GroundChecker _groundChecker;

        public bool NeedJump { get; set; } = false;

        private int _currentNumberJump;

        private void Start()
        {
            RechargeJumps();
        }

        private void Update()
        {
            if (_currentNumberJump < NumberDoubleJump && _groundChecker.IsGrounded())
                RechargeJumps();
        }

        private void FixedUpdate()
        {
            if (NeedJump && _currentNumberJump > 0)
                Jump();
        }

        private void Jump()
        {
            _rigidbody2D.linearVelocityY = 0f;

            _rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

            NeedJump = false;
            _currentNumberJump--;
        }

        private void RechargeJumps()
        {
            _currentNumberJump = NumberDoubleJump;
        }
    }
}