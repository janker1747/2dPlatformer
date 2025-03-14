using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private AbilityRadiusView _abilityRadiusView;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private Health _playerHealth;

    private float _damage = 0.5f;
    private float _radius = 10f;
    private float _cooldown = 4f;
    private WaitForSeconds _delay = new WaitForSeconds(6f);
    private float _lastActivatedTime = -Mathf.Infinity;
    private Coroutine _coroutine;

    private const int MaxColliders = 10;
    private Collider2D[] _hitColliders = new Collider2D[MaxColliders];

    public float CooldownDuration => _cooldown;
    public float CooldownEndTime => _lastActivatedTime + _cooldown;

    public void ActivateSkill()
    {
        if (Time.time >= _lastActivatedTime + _cooldown)
        {
            _lastActivatedTime = Time.time;

            _abilityRadiusView.UpdateView(_radius);
            _abilityRadiusView.ShowRadius();

            StartCoroutine(ActivateVampirism());
        }
    }

    private IEnumerator ActivateVampirism()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(DamageDiling());
            yield return _delay;
            _abilityRadiusView.HideRadius();

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private void HealthStretchings(Enemy enemy)
    {
        if (enemy.TryGetComponent(out Health enemyHealth))
        {
            float damagePerSecond = _damage * Time.deltaTime;
            float actualDamage = Mathf.Min(damagePerSecond, enemyHealth.Current);

            enemyHealth.TakeDamage(actualDamage);
            _playerHealth.ApplyHeal(actualDamage);
        }
    }

    private IEnumerator DamageDiling()
    {
        float duration = 6f; 
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Enemy closestEnemy = GetClosestEnemy();

            if (closestEnemy != null)
            {
                HealthStretchings(closestEnemy); 
            }

            yield return null; 
            elapsedTime += Time.deltaTime;
        }
    }

    private Enemy GetClosestEnemy()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _hitColliders, _targetLayer);
        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Vector2 selfPosition = transform.position;

        for (int i = 0; i < count; i++)
        {
            Collider2D collider = _hitColliders[i];

            if (collider != null && collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Vector2 enemyPosition = enemy.transform.position;
                Vector2 toEnemy = enemyPosition - selfPosition;
                float distance = toEnemy.sqrMagnitude;

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
