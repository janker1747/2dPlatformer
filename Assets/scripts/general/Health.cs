using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3f;
    private float _currentHealth;
    private float _minHealth = 0;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        Debug.Log($"{gameObject.name} health initialized to {_currentHealth}.");
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{gameObject.name} took {damage} damage.");
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Debug.Log($"{gameObject.name} died.");
            Die();
        }
        else
        {
            Debug.Log($"{gameObject.name} current health: {_currentHealth}.");
        }
    }

    public void Heal(float amount)
    {
        if (amount > 0)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
            Debug.Log($"{gameObject.name} healed to {_currentHealth}.");
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} is destroyed.");
        Destroy(gameObject);
    }
}