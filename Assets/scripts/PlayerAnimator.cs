using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string speed = nameof(speed);
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public static class Params
    {
        public static readonly int Speed = Animator.StringToHash(nameof(speed));
    }
    private void LogParameters()
    {
        float speed = _animator.GetFloat(PlayerAnimator.Params.Speed);
    }

    public void SetRunning(float speed)
    {
        _animator.SetFloat(PlayerAnimator.Params.Speed, Mathf.Abs(speed));
    }
}
