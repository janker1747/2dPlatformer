using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    private const float Min = 0;

    [SerializeField] private float _max = 3f;
    private float _current;

    public float Current => _current;
    public float Max => _max;

    public event Action<float> HealthChanged;
    public event Action OnDeath;

    private void Awake()
    {
        _current = _max;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            return;
        }

        _current -= damage;
        _current = Mathf.Clamp(_current, Min, _max);

        Debug.Log($"{name} получил {damage} урона. Осталось здоровья: {_current}");

        HealthChanged?.Invoke(_current/ _max);

        if (_current <= Min)
        {
            Die();
        }
    }

    public void ApplyHeal(float amount)
    {
        if (amount < 0)
        {
            return;
        }

        _current += amount;
        _current = Mathf.Clamp(_current, Min, _max);

        HealthChanged?.Invoke(_current / _max);
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }
}