using Assets._Digger.Scripts.Input;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player
{
    [RequireComponent(typeof(Movement))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Movement _movement;

        private PlayerInputActions _input;

        private void Awake()
        {
            _input = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _input.Player.Move.performed += _movement.Move;
            _input.Player.Move.canceled += _movement.Move;
            _input.Player.Jump.performed += _movement.Jump;

            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Player.Move.performed -= _movement.Move;
            _input.Player.Move.canceled -= _movement.Move;
            _input.Player.Jump.performed -= _movement.Jump;

            _input.Disable();
        }
    }
}