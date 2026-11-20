using System;

namespace Assets._Digger.Scripts.Units
{
    public interface IHealthable
    {
        event Action<int> Changed;
        event Action Died;

        int Min { get; }
        int Max { get; }
        int Value { get; }
    }
}