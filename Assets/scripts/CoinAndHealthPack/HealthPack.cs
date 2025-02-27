using UnityEngine;

public class HealthPack : CollectibleItem
{
    [SerializeField] private float _healAmount = 1f; 

    public float HealAmount => _healAmount; 
}
