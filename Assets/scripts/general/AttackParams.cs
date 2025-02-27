
using UnityEngine;

public class AttackParams : MonoBehaviour
{
    private const string IsAttack = nameof(IsAttack);
    private const string BanditAttack = nameof(BanditAttack);

    public static readonly int isAttack = Animator.StringToHash(nameof(IsAttack));
    public static readonly int banditAttack = Animator.StringToHash(nameof(BanditAttack));
}

