using Assets._Digger.Scripts.Units;
using UnityEngine;

namespace Assets._Digger.Scripts.Objects
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable unit))
                unit.TakeDamage(int.MaxValue);
        }
    }
}