using UnityEngine;

public class AbilityRadius : MonoBehaviour
{
    [SerializeField] private float _radius = 10f;

    public float Radius => _radius;

    public void SetRadius(float radius)
    {
        _radius = radius;
    }
}