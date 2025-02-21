using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string Speed = nameof(Speed);
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public static class Params
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
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
