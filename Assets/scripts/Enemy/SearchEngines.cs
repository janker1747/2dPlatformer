using UnityEngine;
using System;

public class SearchEngines : MonoBehaviour
{
    [SerializeField] private float _detectionRange = 5f;
    [SerializeField] private LayerMask _targetLayer;

    public event Action<Transform> PlayerFound;
    public event Action PlayerLost;

    private Transform _playerTransform;
    private bool _isPlayerInRange;

    private void Update()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _detectionRange, _targetLayer);
        Debug.Log($"Found {targets.Length} targets in detection range.");

        bool playerFound = false;

        foreach (var target in targets)
        {
            if (target.TryGetComponent(out Knight knight))
            {
                _playerTransform = target.transform;
                playerFound = true;
                Debug.Log("Player found: " + _playerTransform.name);
                break;
            }
        }

        if (playerFound && !_isPlayerInRange)
        {
            _isPlayerInRange = true;
            Debug.Log("Player entered detection range.");
            PlayerFound?.Invoke(_playerTransform);
        }
        else if (!playerFound && _isPlayerInRange)
        {
            _isPlayerInRange = false;
            Debug.Log("Player left detection range.");
            PlayerLost?.Invoke();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}