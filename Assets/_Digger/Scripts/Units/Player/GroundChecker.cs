using UnityEngine;

namespace Assets._Digger.Scripts.Units.Player
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius = 0.15f;

        public bool IsGrounded()
        {
            Collider2D[] colliders =
                Physics2D.OverlapCircleAll(_groundCheck.position, _groundCheckRadius);

            foreach (var collider in colliders)
                if (collider.TryGetComponent(out Ground _) == true)
                    return true;

            return false;
        }

        private void OnDrawGizmosSelected()
        {
            if (_groundCheck == null)
                return;
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
        }
    }
}