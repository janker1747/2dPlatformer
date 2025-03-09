using TMPro;
using UnityEngine;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TMP_Text _textMaxHealth;
    [SerializeField] private TMP_Text _textCurrentHealth;

    protected override void OnHealthChanged(float healthPercentage)
    {
        _textCurrentHealth.text = Health.Current.ToString();
        _textMaxHealth.text = Health.Max.ToString();
    }
}