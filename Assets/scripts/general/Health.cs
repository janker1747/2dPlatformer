using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3f;
    private float _currentHealth;
    private float _minHealth = 0;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth,_minHealth, _maxHealth);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
