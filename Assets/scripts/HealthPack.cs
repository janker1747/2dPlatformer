using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private float _healAmount = 1f; 

    public float HealAmount => _healAmount; 
}
