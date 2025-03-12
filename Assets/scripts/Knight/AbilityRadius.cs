
using UnityEngine;

public class AbilityRadius : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _radiusIndicator;

   private void Awake()
    {
        _radiusIndicator = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _radiusIndicator.enabled = false;
    }

    public void ShowRadius()
    {
        _radiusIndicator.enabled = true;
    }
}