using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Flipper _flipper;

    private Rigidbody2D _rigidbody;
    private float _speed = 5f;
    private float _jumpForce = 10f;
    private float _horizontalMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.JumpPressed += TryJump;
        _inputReader.HorizontalChanged += OnHorizontalChanged;
    }

    private void OnDisable()
    {
        _inputReader.JumpPressed -= TryJump;
        _inputReader.HorizontalChanged -= OnHorizontalChanged;
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(_horizontalMove, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
        }
    }

    private void OnHorizontalChanged(float direction)
    {
        _horizontalMove = direction * _speed;
        _animator.SetRunning(Mathf.Abs(_horizontalMove));
        _flipper.Flip(direction);
    }

    private void TryJump()
    {
        if (_groundChecker.IsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
