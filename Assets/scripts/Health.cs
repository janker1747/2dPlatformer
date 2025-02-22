using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3f;
    private float _currentHealth;

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
        _currentHealth += amount;
        _currentHealth = Mathf.Min(_currentHealth, _maxHealth); 
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
