using System;
using UnityEngine;

namespace Assets._Digger.Scripts.Units
{
    public class Health : IHealthable
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public event Action Died;
        public event Action<int> Changed;

        public int Min => _minValue;
        public int Max => _maxValue;
        public int Value { get; private set; }

        public Health(int maxValue)
        {
            _minValue = 0;
            _maxValue = maxValue;
            Value = maxValue;
        }

        public void Set(int value)
        {
            Value = Mathf.Clamp(value, _minValue, _maxValue);

            if (Value <= _minValue)
                Died?.Invoke();

            Changed?.Invoke(Value);
        }

        public void Reset()
        {
            Set(_maxValue);
        }
    }
}