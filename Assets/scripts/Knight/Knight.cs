using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(KnightCombat))]
[RequireComponent(typeof(KnightAnimator))]
[RequireComponent(typeof(KnightCollisionHandler))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(Vampirism))]

public class Knight : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Attacker _attack;
    [SerializeField] private Health _health;

    private Vampirism _vampirism;
    private PlayerMover _playerController;
    private KnightCombat _combat;
    private KnightCollisionHandler _collisionHandler;
    private KnightAnimator _animator;

    private void Awake()
    {
        _playerController = GetComponent<PlayerMover>();
        _combat = GetComponent<KnightCombat>();
        _collisionHandler = GetComponent<KnightCollisionHandler>();
        _animator = GetComponent<KnightAnimator>();
        _vampirism = GetComponent<Vampirism>();

        _combat.Initialize(_attack, _animator);
    }

    private void OnEnable()
    {
        _health.OnDeath += HandleDeath;
        _inputReader.AttackPressed += _combat.Attack;
        _inputReader.JumpPressed += _playerController.TryJump;
        _inputReader.HorizontalChanged += OnHorizontalChanged;
        _inputReader.VampirismPressed += _vampirism.ActivateSkill;
        _collisionHandler.HealthPackCollected += HandleHealthPackCollected;

    }

    private void OnDisable()
    {
        _inputReader.AttackPressed -= _combat.Attack;
        _inputReader.JumpPressed -= _playerController.TryJump;
        _inputReader.HorizontalChanged -= OnHorizontalChanged;
        _inputReader.VampirismPressed -= _vampirism.ActivateSkill;
        _collisionHandler.HealthPackCollected -= HandleHealthPackCollected;

        _health.OnDeath -= HandleDeath;
    }

    private void OnHorizontalChanged(float direction)
    {
        _animator.SetSpeed(Mathf.Abs(direction));

        if (direction != 0)
            _flipper.Flip(direction);
    }

    private void HandleHealthPackCollected(float healAmount)
    {
        _health.ApplyHeal(healAmount); 
    }

    private void HandleDeath()
    {
        Destroy(gameObject);
    }
}