using UnityEngine;

public class KnightAnimator : MonoBehaviour 
{
    protected Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        _animator.SetTrigger(AttackParams.KnightAttack);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(MovementParams.ChacterSpeed, Mathf.Abs(speed));
    }
}