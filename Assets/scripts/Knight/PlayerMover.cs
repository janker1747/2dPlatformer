using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private Flipper _flipper;
    private float _horizontalMove;
    private bool _isJumpRequested = false;

    public void TryJump()
    {
        _isJumpRequested = true;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();

        _rigidbody.drag = 0;
        _rigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    private void OnEnable()
    {
        _inputReader.HorizontalChanged += OnHorizontalChanged;
        _inputReader.JumpPressed += TryJump;
    }

    private void OnDisable()
    {
        _inputReader.HorizontalChanged -= OnHorizontalChanged;
        _inputReader.JumpPressed -= TryJump;
    }

    private void OnHorizontalChanged(float direction)
    {
        _horizontalMove = direction * _moveSpeed;

        if (direction != 0)
            _flipper?.Flip(direction);
    }

    private void FixedUpdate()
    {
        Move();
        HandleJump();
    }

    private void Move()
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = _horizontalMove;
        _rigidbody.velocity = velocity;
    }

    private void HandleJump()
    {
        if (_isJumpRequested && _groundChecker.IsGrounded())
        {
            Debug.Log("Jumping!");
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isJumpRequested = false;
        }
    }

}