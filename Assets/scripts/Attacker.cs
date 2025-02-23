using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _attackRange = 2f;
    [SerializeField] private float _attackDamage = 1f;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private LayerMask _targetLayer;

    private float _lastAttackTime;

    public void TryAttack(GameObject attacker)
    {
        _lastAttackTime -= Time.time;

        if (_lastAttackTime < _attackCooldown)
            return;

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _attackRange, _targetLayer);

        foreach (Collider2D target in targets)
        {
            if (target.gameObject == attacker)
                continue;

            if (target.TryGetComponent(out Health health))
            {
                health.TakeDamage(_attackDamage);
            }
        }

        _lastAttackTime = Time.time;
    }
}
