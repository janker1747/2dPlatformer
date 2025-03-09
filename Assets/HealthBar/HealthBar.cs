using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] private  Health _health;

    protected Health Health => _health;

    protected virtual void Awake()
    {
        if (_health == null)
        {
            return;
        }

        _health.HealthChanged += OnHealthChanged;
    }

    protected virtual void OnDestroy()
    {
        if (_health != null)
        {
            _health.HealthChanged -= OnHealthChanged;
        }
    }

    protected abstract void OnHealthChanged(float healthPercentage);
}