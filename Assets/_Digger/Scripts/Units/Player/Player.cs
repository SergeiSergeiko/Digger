using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Input;
using Assets._Digger.Scripts.Units.Player.FSM.States;
using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player
{
    [RequireComponent(typeof(Movement))]
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private Jumper _jumper;
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerConfigSO _config;

        private PlayerInputActions _input;
        private StateMachine<PlayerStates> _fsm;
        private Health _health;

        public IHealthable Health => _health;

        private void Awake()
        {
            InitConfig();
            _input = new PlayerInputActions();

            InitStateMachine();
            _fsm.SetState(PlayerStates.IDLE);
        }

        private void OnEnable()
        {
            _input.Enable();
            _health.Died += Die;
        }

        private void OnDisable()
        {
            _input.Disable();
            _health.Died -= Die;
        }

        private void Update()
        {
            _fsm.Update();
        }

        public void TakeDamage(int damage)
        {
            _health.HealthValue = _health.HealthValue - damage;
        }

        public void ResetState()
        {
            _fsm.SetState(PlayerStates.IDLE);
            _health.Reset();
            _input.Enable();
            _movement.ResetState();
        }
        
        private void Die()
        {
            _fsm.SetState(PlayerStates.DIE);
            _input.Disable();
        }

        private void InitStateMachine()
        {
            _fsm = new StateMachine<PlayerStates>();
            var idleState = new IdleState(_fsm, _input, _groundChecker, this, _animator);
            var moveState = new MoveState(_fsm, _input, _groundChecker, _movement, _animator);
            var jumpState = new JumpState(_fsm, _input, _groundChecker, _movement, _jumper, _animator);
            var attackState = new AttackState(_fsm, _animator);
            var dieState = new DieState(_animator);
            var airState = new AirState(_fsm, _input, _groundChecker, _movement, _animator);

            _fsm.AddState(PlayerStates.IDLE, idleState);
            _fsm.AddState(PlayerStates.MOVE, moveState);
            _fsm.AddState(PlayerStates.JUMP, jumpState);
            _fsm.AddState(PlayerStates.ATTACK, attackState);
            _fsm.AddState(PlayerStates.DIE, dieState);
            _fsm.AddState(PlayerStates.AIR, airState);
        }

        private void InitConfig()
        {
            _health = new Health(_config.MaxHealth);
            _movement.Speed = _config.MoveSpeed;
            _jumper.JumpForce = _config.JumpForce;
            _jumper.CountMultiJump = _config.NumberDoubleJump;
        }
    }
}