using System;
using UnityEngine;

public class Coin : CollectibleItem
{
    public event Action<Coin> Collected; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collected?.Invoke(this);
    }
}