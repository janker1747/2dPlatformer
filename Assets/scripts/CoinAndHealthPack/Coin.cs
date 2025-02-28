using System;
using UnityEngine;

public class Coin : CollectibleItem
{
    public event Action<Coin> Collect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Collect?.Invoke(this);
        }
    }
}
