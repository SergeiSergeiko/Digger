using Assets._Digger.Scripts.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._Digger.Scripts.Units.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private bool _isButtonJumpClick;

        private Rigidbody2D _rigidbody2D;
        private PlayerInputActions _inputActions;
        private float _moveDirection;

        private void Awake()
        {
            _inputActions = new();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _inputActions.Player.Move.performed += ButtonMoveClickHandler;
            _inputActions.Player.Move.canceled += ButtonMoveClickHandler;
            _inputActions.Player.Jump.performed += ButtonJumpClickHandler;

            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Player.Move.performed -= ButtonMoveClickHandler;
            _inputActions.Player.Move.canceled -= ButtonMoveClickHandler;
            _inputActions.Player.Jump.performed -= ButtonJumpClickHandler;
        }

        private void FixedUpdate()
        {
            _rigidbody2D.linearVelocity = new(
                _moveDirection * _speed,
                _rigidbody2D.linearVelocity.y);

            if (_isButtonJumpClick)
                Jump();
        }

        private void Jump()
        {
            _rigidbody2D.AddForceY(_jumpForce, ForceMode2D.Impulse);

            _isButtonJumpClick = false;
        }

        private void ButtonMoveClickHandler(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<float>();
        }

        private void ButtonJumpClickHandler(InputAction.CallbackContext _)
        {
            _isButtonJumpClick = true;
        }
    }
}