using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _chaseSpeed = 5f;
    [SerializeField] private float _attackRange = 1.5f;
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Chaser _chaser;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Attacker _attack;

    private Transform _playerTransform;
    private bool _isChasing;

    private void OnEnable()
    {
        if (_chaser != null)
        {
            _chaser.PlayerFound += StartChasing;
            _chaser.PlayerLost += StopChasing;
        }
    }

    private void OnDisable()
    {
        if (_chaser != null)
        {
            _chaser.PlayerFound -= StartChasing;
            _chaser.PlayerLost -= StopChasing;
        }
    }

    private void Update()
    {
        if (_isChasing && _playerTransform != null)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void StartChasing(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _isChasing = true;
    }

    private void StopChasing()
    {
        _playerTransform = null;
        _isChasing = false;
    }

    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _playerTransform.position,
            _chaseSpeed * Time.deltaTime
        );

        if (_flipper != null)
        {
            _flipper.Flip(_playerTransform.position.x - transform.position.x);
        }

        if (Vector2.Distance(transform.position, _playerTransform.position) <= _attackRange)
        {
            AttackPlayer();
        }
    }

    private void Patrol()
    {
        if (_patroller != null)
        {
            _patroller.Move(transform, _flipper);
        }
    }

    private void AttackPlayer()
    {
        if (_attack != null)
        {
            _attack.TryAttack(gameObject);
        }
    }
}