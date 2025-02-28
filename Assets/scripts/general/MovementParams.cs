using UnityEngine;

public class MovementParams : MonoBehaviour
{
    private const string Speed = nameof(Speed);

    public static readonly int ChacterSpeed = Animator.StringToHash(nameof(Speed));
}
