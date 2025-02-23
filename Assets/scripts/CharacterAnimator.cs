using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void LogParameters()
    {
        float speed = _animator.GetFloat(Params.Speed);
        bool isEnemyAttack = _animator.GetBool(Params.IsAttack);
    }

    public void StartRunning(float speed)
    {
        _animator.SetFloat(Params.Speed, Mathf.Abs(speed));
    }

    public void StartAttack()
    {
        _animator.SetTrigger(Params.IsAttack);
    }
}
