using System;
using UnityEngine;

public class KnightCollisionHandler : MonoBehaviour
{
    public event Action<float> HealthPackCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CollectibleItem collectible))
        {
            if (collectible is HealthPack healthPack)
            {
                HealthPackCollected?.Invoke(healthPack.HealAmount);
                Destroy(healthPack.gameObject);
            }
            else if (collectible is Coin coin) 
            {
                Destroy(coin.gameObject);
            }
        }
    }
}