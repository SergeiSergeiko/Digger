using System;
using UnityEngine;

namespace Assets._Digger.Scripts.Units
{
    public class Health : IHealthable
    {
        public event Action Died;
        public event Action<int> Changed;

        public int MinHealthValue { get; private set; }
        public int MaxHealthValue { get; private set; }
        public int HealthValue
        {
            get
            {
                return HealthValue;
            }

            set
            {
                HealthValue = Mathf.Clamp(value, MinHealthValue, MaxHealthValue);

                if (HealthValue <= MinHealthValue)
                    Died?.Invoke();

                Changed?.Invoke(HealthValue);
            }
        }

        public Health(int maxValue)
        {
            MinHealthValue = 0;
            MaxHealthValue = maxValue;
            HealthValue = maxValue;
        }

        public void Reset()
        {
            HealthValue = MaxHealthValue;
        }
    }
}