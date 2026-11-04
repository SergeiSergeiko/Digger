using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Digger.Scripts.Units
{
    public class Fliper : MonoBehaviour
    {
        [SerializeField] private Transform _weaponPos;
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

                    FlipXWeapon();
                }
            }

            if (direction < 0)
            {
                if (_isFliped == false)
                {
                    foreach (var sprite in _sprites)
                        sprite.flipX = true;

                    FlipXWeapon();
                }
            }
        }

        private void FlipXWeapon()
        {
            Vector2 newPos = new(_weaponPos.position.x * -1, _weaponPos.position.y);
            _weaponPos.position = newPos;
        }
    }
}