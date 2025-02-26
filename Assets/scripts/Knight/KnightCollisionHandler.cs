using UnityEngine;

public class KnightCollisionHandler : MonoBehaviour
{
    private Health _health;

    public void Initialize(Health health)
    {
        _health = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out _))
        {
            Destroy(collision.gameObject);
        }

        if (collision.TryGetComponent<HealthPack>(out HealthPack healthPack))
        {
            _health?.Heal(healthPack.HealAmount);
            Destroy(healthPack.gameObject);
        }
    }
}
