using UnityEngine;

public static class MovementParams
{
    private const string Speed = nameof(Speed);

    public static readonly int speed = Animator.StringToHash(nameof(Speed));
}
