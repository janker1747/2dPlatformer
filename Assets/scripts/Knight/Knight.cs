using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(KnightCombat))]
[RequireComponent(typeof(KnightAnimator))]
[RequireComponent(typeof(KnightCollisionHandler))]

public class Knight : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Attacker _attack;
    [SerializeField] private Health _health;

    private PlayerController _playerController;
    private KnightCombat _combat;
    private KnightCollisionHandler _collisionHandler;
    private KnightAnimator _animator;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _combat = GetComponent<KnightCombat>();
        _collisionHandler = GetComponent<KnightCollisionHandler>();
        _animator = GetComponent<KnightAnimator>();

        _combat.Initialize(_attack, _animator);
        _collisionHandler.Initialize(_health);
    }

    private void OnEnable()
    {
        _inputReader.AttackPressed += _combat.Attack;
        _inputReader.JumpPressed += _playerController.TryJump;
        _inputReader.HorizontalChanged += OnHorizontalChanged;
    }

    private void OnDisable()
    {
        _inputReader.AttackPressed -= _combat.Attack;
        _inputReader.JumpPressed -= _playerController.TryJump;
        _inputReader.HorizontalChanged -= OnHorizontalChanged;
    }

    private void OnHorizontalChanged(float direction)
    {
        _animator.StartRunning(Mathf.Abs(direction));

        if (direction != 0)
            _flipper.Flip(direction);
    }
}