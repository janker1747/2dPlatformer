using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    private EnemyMover _mover;
    private EnemyCombat _combat;
    private Transform _playerTransform;
    private bool _isChasing;

    public void Initialize(EnemyMover mover, EnemyCombat combat)
    {
        _mover = mover;
        _combat = combat;
    }

    public void StartChasing(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _isChasing = true;
        _mover.StartChasing(playerTransform);
    }

    public void StopChasing()
    {
        _playerTransform = null;
        _isChasing = false;
        _mover.StopChasing();
    }

    private void Update()
    {
        if (_isChasing && _playerTransform != null)
        {
            if (_combat.CanAttack(transform.position, _playerTransform.position))
            {
                _combat.Attack(gameObject);
            }
            else
            {
                _mover.StartChasing(_playerTransform);
            }
        }
    }
}