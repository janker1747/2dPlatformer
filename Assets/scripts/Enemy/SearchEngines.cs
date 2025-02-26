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

        if (playerFound && _isPlayerInRange == false)
        {
            _isPlayerInRange = true;
            PlayerFound?.Invoke(_playerTransform);
        }
        else if (playerFound == false && _isPlayerInRange)
        {
            _isPlayerInRange = false;
            PlayerLost?.Invoke(); 
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}