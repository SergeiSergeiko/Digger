using System.Collections.Generic;
using UnityEngine;

namespace Assets._Digger.Scripts.Units
{
    public class Fliper : MonoBehaviour
    {
        [SerializeField] private Transform _weapon;
        [SerializeField] private List<SpriteRenderer> _sprites;

        private bool _isFliped = false;

        public void FlipX(float direction)
        {
            if (direction > 0)
            {
                if (_isFliped)
                {
                    foreach (var sprite in _sprites)
                        sprite.flipX = false;

                    _isFliped = false;
                }
            }

            if (direction < 0)
            {
                if (_isFliped == false)
                {
                    foreach (var sprite in _sprites)
                        sprite.flipX = true;

                    _isFliped = true;
                }
            }
        }
    }
}