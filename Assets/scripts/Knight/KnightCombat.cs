using UnityEngine;

public class KnightCombat : MonoBehaviour
{
    private Attacker _attack;
    private KnightAnimator _animator;

    public void Initialize(Attacker attack, KnightAnimator animator)
    {
        _attack = attack;
        _animator = animator;
    }

    public void Attack()
    {
        _animator.KnightAttack();
        _attack.TryAttack(gameObject);
    }
}
