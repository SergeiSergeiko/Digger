using System;

namespace Assets._Digger.Scripts.Units
{
    public interface IHealthable
    {
        event Action<int> Changed;
        event Action Died;

        int MinHealthValue { get; }
        int MaxHealthValue { get; }
        int HealthValue { get; }
    }
}