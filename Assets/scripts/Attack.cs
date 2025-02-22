using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackDamage = 1f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private LayerMask targetLayer;

    private float _lastAttackTime;

    public void TryAttack(GameObject attacker)
    {
        if (Time.time - _lastAttackTime < attackCooldown)
            return;

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, attackRange, targetLayer);

        foreach (Collider2D target in targets)
        {
            if (target.gameObject == attacker)
                continue;

            if (target.TryGetComponent(out Health health))
            {
                health.TakeDamage(attackDamage);
            }
        }

        _lastAttackTime = Time.time;
    }
}
