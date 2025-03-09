using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthModifier : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private bool _isHealing;
    [SerializeField] private Button _button;

    public event Action<float> ModifyHealth;

    private void OnEnable()
    {
        if (_button != null)
        {
            _button.onClick.AddListener(Apply);
        }
    }

    private void OnDisable()
    {
        if (_button != null)
        {
            _button.onClick.RemoveListener(Apply);
        }
    }

    public void Apply()
    {
        ModifyHealth?.Invoke(_isHealing ? _value : -_value);
    }
}
