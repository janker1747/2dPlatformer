using System;
using UnityEngine;

public class KnightCollisionHandler : MonoBehaviour
{
    public event Action<float> OnHealthPackCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectibleItem collectible = collision.GetComponent<CollectibleItem>();

        if (collectible != null)
        {
            if (collectible is Coin coin)
            {
                Destroy(collision.gameObject);
            }
            else if (collectible is HealthPack healthPack)
            {
                OnHealthPackCollected?.Invoke(healthPack.HealAmount);

                Destroy(healthPack.gameObject);
            }

        }
    }
}
