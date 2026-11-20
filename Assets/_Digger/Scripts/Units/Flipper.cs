using UnityEngine;

namespace Assets._Digger.Scripts.Units
{
    public class Flipper : MonoBehaviour
    {
        [SerializeField] private Transform _owner;

        private float _flipValue = 180f;

        public void FlipX(float direction)
        {
            if (direction > 0)
            {
                if (_owner.rotation.y > 0)
                {
                    SetQuaternionOwnerY(0);
                }
            }
            else if (direction < 0) 
            {
                if (_owner.rotation.y < _flipValue)
                {
                    SetQuaternionOwnerY(_flipValue);
                }
            }
        }

        private void SetQuaternionOwnerY(float y)
        {
            _owner.rotation = new Quaternion(
                _owner.rotation.x,
                y,
                _owner.rotation.z,
                _owner.rotation.w);
        }
    }
}