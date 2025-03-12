using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] Vampirism _vampirism;

    private void Update()
    {
        float cooldownProgress = Mathf.Clamp01((_vampirism.CooldownEndTime - Time.time) / _vampirism.CooldownDuration);
        _slider.value = 1 - cooldownProgress;
    }
}
