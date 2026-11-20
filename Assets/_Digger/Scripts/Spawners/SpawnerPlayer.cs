using Assets._Digger.Scripts.Units.Player;
using UnityEngine;

namespace Assets._Digger.Scripts.Spawners
{
    public class SpawnerPlayer : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void Spawn(Player player, Vector3 pos)
        {
            player.transform.position = pos;
        }

        public Player CreatePlayer()
        {
            return Instantiate(_player);
        }
    }
}