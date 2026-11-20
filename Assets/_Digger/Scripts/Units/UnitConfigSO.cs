using UnityEngine;

namespace Assets._Digger.Scripts.Units
{
    [CreateAssetMenu(fileName = "NewConfig", menuName = "Configs/Unit")]
    public class UnitConfigSO : ScriptableObject
    {
        public int MaxHealth;
        public float JumpForce;
        public float MoveSpeed;
    }
}