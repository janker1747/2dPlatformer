using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private Image _fillingBar;

    private float _targetFillAmount;
    private Coroutine _smoothCoroutine;

    protected override void OnHealthChanged(float healthPercentage)
    {
        _targetFillAmount = healthPercentage;

        if (_smoothCoroutine != null)
        {
            StopCoroutine(_smoothCoroutine);
        }
        _smoothCoroutine = StartCoroutine(SmoothFill());
    }

    private IEnumerator SmoothFill()
    {
        float smoothSpeed = 5f;
        float fillPrecision = 0.01f;

        while (Mathf.Abs(_fillingBar.fillAmount - _targetFillAmount) > fillPrecision)
        {
            _fillingBar.fillAmount = Mathf.Lerp(_fillingBar.fillAmount, _targetFillAmount, Time.deltaTime * smoothSpeed);
            yield return null;
        }

        _fillingBar.fillAmount = _targetFillAmount;
    }
}