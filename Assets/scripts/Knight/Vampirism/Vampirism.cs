using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private AbilityRadius _abilityRadius;
    [SerializeField] private AbilityRadiusView _abilityRadiusView;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private Health _playerHealth;

    private float _damage = 0.5f;
    private float _radius = 10f;
    private float _cooldown = 4f;
    private float _action = 6f;
    private float _lastActivatedTime = -Mathf.Infinity;
    private Coroutine _coroutine;

    public float CooldownDuration => _cooldown; 
    public float CooldownEndTime => _lastActivatedTime + _cooldown;

    public void ActivateSkill()
    {
        if (Time.time >= _lastActivatedTime + _cooldown)
        {
            _lastActivatedTime = Time.time;

            _abilityRadiusView.ShowRadius();
            _abilityRadiusView.UpdateView();

            StartCoroutine(ActivateVampirism());
        }
    }

    private IEnumerator ActivateVampirism()
    {
        WaitForSeconds activateTime = new WaitForSeconds(_action);

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(DamageDiling());
            yield return activateTime;
            _abilityRadiusView.HideRadius();
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void HealthStretchings(Enemy enemy)
    {
        if (enemy.TryGetComponent(out Health enemyHealth))
        {
            float damagePerSecond = _damage;
            float actualDamage = Mathf.Min(damagePerSecond, enemyHealth.Current);

            enemyHealth.TakeDamage(actualDamage);
           _playerHealth.ApplyHeal(actualDamage);
        }
    }

    private IEnumerator DamageDiling()
    {
        float elapsedTime = 0f;
        float tickInterval = 0.1f; 

        while (true)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= tickInterval)
            {
                elapsedTime = 0f;

                Enemy closestEnemy = GetClosestEnemy();

                if (closestEnemy != null)
                {
                    HealthStretchings(closestEnemy);
                }
            }

            yield return null; 
        }
    }

    private Enemy GetClosestEnemy()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _radius, _targetLayer);
        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);

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
