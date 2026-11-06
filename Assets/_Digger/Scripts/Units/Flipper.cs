using UnityEngine;

namespace Assets._Digger.Scripts.Units
{
    public class Flipper : MonoBehaviour
    {
        [SerializeField] private Transform _owner;

        private bool _isFliped = false;
        private float _flipValue = 180;

        public void FlipX(float direction)
        {
            if (direction > 0)
            {
                if (_isFliped)
                {
                    SetQuaternionOwnerY(0);
                    _isFliped = false;
                }
            }

            if (direction < 0)
            {
                if (_isFliped == false)
                {
                    SetQuaternionOwnerY(_flipValue);
                    _isFliped = true;
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