using Assets._Digger.Scripts.Units;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Digger.Scripts.Game.Gameplay.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private IHealthable _health;

        private void OnDisable()
        {
            _health.Changed -= OnHealthChanged;
        }

        public void AttachHealth(IHealthable health)
        {
            if (_health != null)
                _health.Changed -= OnHealthChanged;

            _health = health;

            _slider.minValue = _health.Min;
            _slider.maxValue = _health.Max;
            _slider.value = _health.Value;

            _health.Changed += OnHealthChanged;
        }

        private void OnHealthChanged(int value)
        {
            _slider.value = value;
        }
    }
}