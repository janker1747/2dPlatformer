using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private AbilityRadius _abilityRadius;
    [SerializeField] private LayerMask _targetLayer;

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
            Debug.Log("Навык активировался");
            _lastActivatedTime = Time.time;

            StartCoroutine(ActivateVampirism());

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Навык на кулдауне");
        }
    }

    private IEnumerator ActivateVampirism()
    {
        if (_coroutine == null)
        {
            _abilityRadius.ShowRadius();
            _coroutine = StartCoroutine(DamageDiling());
            yield return new WaitForSeconds(_action);
            StopCoroutine(_coroutine);
        }
    }


    private void HealthStretchings(Enemy enemy)
    {
        if (enemy.TryGetComponent(out Health enemyHealth))
        {
            float damagePerSecond = _damage;
            enemyHealth.TakeDamage(damagePerSecond);

            if (TryGetComponent(out Health playerHealth))
            {
                playerHealth.ApplyHeal(damagePerSecond);
            }
        }
    }

    private IEnumerator DamageDiling()
    {
        WaitForSeconds _delay = new WaitForSeconds(0.1f);

        while (true)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _radius, _targetLayer);


            if (hitColliders.Length > 0)
            {
                foreach (Collider2D collider in hitColliders)
                {
                    if (collider.TryGetComponent<Enemy>(out Enemy enemy))
                    {
                        HealthStretchings(enemy);
                    }
                }
            }

            yield return _delay;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
