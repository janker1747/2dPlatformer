using UnityEngine;

public class AttackParams : MonoBehaviour
{
    private const string IsAttack = nameof(IsAttack);
    private const string EnemyAttack = nameof(EnemyAttack);

    public static readonly int KnightAttack = Animator.StringToHash(nameof(IsAttack));
    public static readonly int BanditAttack = Animator.StringToHash(nameof(EnemyAttack));
}

