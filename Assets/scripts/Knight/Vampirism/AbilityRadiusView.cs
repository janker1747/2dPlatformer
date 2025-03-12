using UnityEngine;

public class AbilityRadiusView : MonoBehaviour
{
    [SerializeField] private AbilityRadius _abilityRadius;
    [SerializeField] private SpriteRenderer _radiusIndicator;

    private void Awake()
    {
        _radiusIndicator = GetComponent<SpriteRenderer>();
        _radiusIndicator.enabled = false;
    }

    public void UpdateView()
    {
        float spriteScale = 2f;

        transform.localScale = Vector3.one * _abilityRadius.Radius * spriteScale; 
    }

    public void ShowRadius()
    {
        _radiusIndicator.enabled = true;
    }

    public void HideRadius()
    {
        _radiusIndicator.enabled = false;
    }
}
