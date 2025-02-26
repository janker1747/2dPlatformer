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
        _animator.SetTrigger(Params.IsAttack);
    }

    public void StartRunning(float speed)
    {
        _animator.SetFloat(Params.Speed, Mathf.Abs(speed));
    }
}