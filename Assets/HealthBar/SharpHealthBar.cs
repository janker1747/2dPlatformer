using UnityEngine;
using UnityEngine.UI;

public class SharpHealthBar : HealthBar
{
    [SerializeField] private Slider _fillingBar;

    protected override void OnHealthChanged(float healthPercentage)
    {
        _fillingBar.value = healthPercentage;
    }
}