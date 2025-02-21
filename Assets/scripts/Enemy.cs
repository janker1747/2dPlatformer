using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Flipper _flipper;

    private void Update()
    {
        _patroller.Move(transform, _flipper);
        _animator.SetRunning(Mathf.Abs(transform.position.x));
    }
}
