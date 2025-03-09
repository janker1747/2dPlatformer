using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _attackRange = 2f;
    [SerializeField] private float _attackDamage = 1f;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private LayerMask _targetLayer;

    private float _attackOffset;
    private float _lastAttackTime;

    public void TryAttack()
    {
        if (Time.time - _lastAttackTime < _attackCooldown)
        {
            return;
        }

        Vector2 attackDirection = transform.right;
        Vector2 attackPosition = (Vector2)transform.position + attackDirection * _attackOffset;

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _attackRange, _targetLayer);

        foreach (Collider2D target in targets)
        {
            if (target.TryGetComponent(out Health health))
            {
                health.TakeDamage(_attackDamage);
            }
        }

        _lastAttackTime = Time.time;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}