using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _checkRadius = 0.1f;

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _groundLayer);
    }
}
