using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _mask;
        [SerializeField] private float _distance = 0.15f;

        private RaycastHit2D hit;

        public bool IsGrounded()
        {
            hit =  Physics2D.Raycast(_groundCheck.position, Vector2.down, _distance, _mask);

            return hit;
        }

        private void OnDrawGizmosSelected()
        {
            if (_groundCheck == null)
                return;

            Debug.DrawRay(
                _groundCheck.position, Vector2.down * _distance, hit ? Color.green : Color.red);
        }
    }
}