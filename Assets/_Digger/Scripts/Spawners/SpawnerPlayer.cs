using Assets._Digger.Scripts.Units.Player;
using UnityEngine;

namespace Assets._Digger.Scripts.Spawners
{
    public class SpawnerPlayer : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private bool _isCreated = false;

        public void Init()
        {

        }

        public void Spawn(Player player, Vector3 pos)
        {
            player.transform.position = pos;
        }

        public Player CreatePlayer()
        {
            if (_isCreated == false)
                return _player = Instantiate(_player);
            else
                return _player;
        }
    }
}