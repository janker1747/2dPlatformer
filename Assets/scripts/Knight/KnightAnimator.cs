using UnityEngine;

public class KnightAnimator : MonoBehaviour 
{
    protected Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void KnightAttack()
    {
        _animator.SetTrigger(AttackParams.isAttack);
    }

    public void StartRunning(float speed)
    {
        _animator.SetFloat(MovementParams.speed, Mathf.Abs(speed));
    }
}