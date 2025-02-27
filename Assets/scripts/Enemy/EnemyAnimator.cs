using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimator : KnightAnimator
{
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void EnemyRunning(float speed)
    {
  
        _animator.SetFloat(MovementParams.speed, Mathf.Abs(speed));
    }

    public void EnemyAttack()
    {
        _animator.SetTrigger(AttackParams.banditAttack);
    }
}
