using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private Attacker _attacker;
    private EnemyAnimator _animator;
    private float _attackRange;

    public void Initialize(Attacker attacker, EnemyAnimator animator, float attackRange)
    {
        _attacker = attacker;
        _animator = animator;
        _attackRange = attackRange;
    }

    public bool CanAttack(Vector2 enemyPosition, Vector2 playerPosition)
    {
        return Vector2.SqrMagnitude(enemyPosition - playerPosition) <= _attackRange * _attackRange;
    }

    public void Attack(GameObject enemy)
    {
        _animator.EnemyAttack();
        _attacker.TryAttack(enemy);
    }
}
