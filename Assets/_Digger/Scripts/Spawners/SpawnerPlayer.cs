using Assets._Digger.Scripts.Units.Player;
using UnityEngine;

namespace _Digger.Scripts.Game.Gameplay
{
    public class SpawnerPlayer : MonoBehaviour
    {
        [SerializeField] private Player Player;
        [SerializeField] private GameObject SpawnPoint;

        public Player Spawn()
        {
            return Instantiate(Player, SpawnPoint.transform.position, Quaternion.identity);
        }
    }
}