using UnityEngine;

[RequireComponent(typeof(EnemyCombat))]
[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyChaser))]
[RequireComponent(typeof(Flipper))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _chaseSpeed = 5f;
    [SerializeField] private float _attackRange = 1.5f;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private SearchEngines _searchEngines;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health; 

    private EnemyMover _mover;
    private EnemyCombat _combat;
    private EnemyChaser _enemyChaser;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _combat = GetComponent<EnemyCombat>();
        _enemyChaser = GetComponent<EnemyChaser>();

        _mover.Initialize(_chaseSpeed, _patroller, GetComponent<Flipper>());
        _combat.Initialize(_attacker, _animator, _attackRange);
        _enemyChaser.Initialize(_mover, _combat);
    }

    private void OnEnable()
    {
        _health.OnDeath += HandleDeath;

        if (_searchEngines != null)
        {
            _searchEngines.PlayerFound += _enemyChaser.StartChasing;
            _searchEngines.PlayerLost += _enemyChaser.StopChasing;
        }
    }

    private void OnDisable()
    {
        if (_searchEngines != null)
        {
            _searchEngines.PlayerFound -= _enemyChaser.StartChasing;
            _searchEngines.PlayerLost -= _enemyChaser.StopChasing;
        }

        _health.OnDeath -= HandleDeath;
    }

    private void HandleDeath()
    {
        Destroy(gameObject);
    }
}