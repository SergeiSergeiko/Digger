using Assets._Digger.Scripts.Units;
using UnityEngine;

namespace Assets._Digger.Scripts.Game.Gameplay.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;

        public void InitHealthBar(IHealthable health)
        {
            _healthBar.AttachHealth(health);
        }
    }
}