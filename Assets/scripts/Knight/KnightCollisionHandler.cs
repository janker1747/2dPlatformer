using System;
using UnityEngine;

public class KnightCollisionHandler : MonoBehaviour
{
    public event Action<float> HealthPackCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectibleItem collectible = collision.GetComponent<CollectibleItem>();

        if (collectible != null)
        {
            if (collectible is HealthPack healthPack)
            {
                HealthPackCollected?.Invoke(healthPack.HealAmount);

                Destroy(healthPack.gameObject);
            }
        }
    }
}
