using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player
{
    [CreateAssetMenu(fileName = "NewConfig", menuName = "Configs/Player")]
    public class PlayerConfigSO : UnitConfigSO
    {
        [Header("Double Jump")]
        public int NumberDoubleJump;
    }
}