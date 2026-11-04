using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.FSM.States;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player
{
    [RequireComponent(typeof(Movement))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private Animator _animator;

        private PlayerInputActions _input;
        private StateMachine<PlayerStates> _stateMachine;

        public bool IsGrounded => _movement.IsGrounded;

        private void Awake()
        {
            _input = new PlayerInputActions();

            InitStateMachine();
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void Start()
        {
            _stateMachine.SetState(PlayerStates.IDLE);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void InitStateMachine()
        {
            _stateMachine = new StateMachine<PlayerStates>();
            var idleState = new IdleState(_stateMachine, _input, _movement, _animator);
            var moveState = new MoveState(_stateMachine, _input, _movement, _animator);
            var jumpState = new JumpState(_stateMachine, _input, _movement, _animator);
            var attackState = new AttackState(_stateMachine, _movement, _animator);
            var dieState = new DieState(_stateMachine, _input, _animator);

            _stateMachine.AddState(PlayerStates.IDLE, idleState);
            _stateMachine.AddState(PlayerStates.MOVE, moveState);
            _stateMachine.AddState(PlayerStates.JUMP, jumpState);
            _stateMachine.AddState(PlayerStates.ATTACK, attackState);
            _stateMachine.AddState(PlayerStates.DIE, dieState);
        }
    }
}