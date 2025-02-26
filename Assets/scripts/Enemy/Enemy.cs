using UnityEngine;

[RequireComponent(typeof(EnemyCombat))]
[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyStateManager))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _chaseSpeed = 5f;
    [SerializeField] private float _attackRange = 1.5f;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private SearchEngines _chaser;
    [SerializeField] private Attacker _attack;

    private EnemyMover _mover;
    private EnemyCombat _combat;
    private EnemyStateManager _stateManager;

    private void Awake()
    {
        _mover = gameObject.AddComponent<EnemyMover>();
        _combat = gameObject.AddComponent<EnemyCombat>();
        _stateManager = gameObject.AddComponent<EnemyStateManager>();

        _mover.Initialize(_chaseSpeed, _patroller, GetComponent<Flipper>());
        _combat.Initialize(_attack, _animator, _attackRange);
        _stateManager.Initialize(_mover, _combat);
    }

    private void OnEnable()
    {
        if (_chaser != null)
        {
            _chaser.PlayerFound += _stateManager.StartChasing;
            _chaser.PlayerLost += _stateManager.StopChasing;
        }
    }

    private void OnDisable()
    {
        if (_chaser != null)
        {
            _chaser.PlayerFound -= _stateManager.StartChasing;
            _chaser.PlayerLost -= _stateManager.StopChasing;
        }
    }
}
