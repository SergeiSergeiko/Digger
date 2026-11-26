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

        public void InitHealth(IHealthable health)
        {
            if (_health != null)
                _health.Changed -= OnHealthChanged;

            _health = health;

            InitSlider();

            _health.Changed += OnHealthChanged;
        }

        private void OnHealthChanged(int value)
        {
            _slider.value = value;
        }

        private void InitSlider()
        {
            _slider.minValue = _health.MinHealthValue;
            _slider.maxValue = _health.MaxHealthValue;
            _slider.value = _health.HealthValue;
        }
    }
}