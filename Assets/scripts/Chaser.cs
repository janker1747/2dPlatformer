using UnityEngine;
using System;

public class Chaser : MonoBehaviour
{
    [SerializeField] private float _detectionRange = 5f;
    [SerializeField] private LayerMask _targetLayer;

    public event Action<Transform> OnPlayerFound; 
    public event Action OnPlayerLost;

    private Transform _playerTransform;
    private bool _isPlayerInRange;

    private void Update()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _detectionRange, _targetLayer);

        bool playerFound = false;
        foreach (Collider2D target in targets)
        {
            if (target.TryGetComponent(out Knight knight))
            {
                _playerTransform = target.transform;
                playerFound = true;
                break;
            }
        }

        if (playerFound && !_isPlayerInRange)
        {
            _isPlayerInRange = true;
            OnPlayerFound?.Invoke(_playerTransform);
        }
        else if (!playerFound && _isPlayerInRange)
        {
            _isPlayerInRange = false;
            OnPlayerLost?.Invoke(); 
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}