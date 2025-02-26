using UnityEngine;

public static class Params
{
    private const string speed = nameof(speed);
    private const string isAttack = nameof(isAttack);
    private const string banditAttack = nameof(BanditAttack);

    public static readonly int BanditAttack = Animator.StringToHash(nameof(BanditAttack));
    public static readonly int Speed = Animator.StringToHash(nameof(speed));
    public static readonly int IsAttack = Animator.StringToHash(nameof(isAttack));
}
