using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] private AnimatorController _animator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private float _speed = 5f;
    private float _jumpForce = 10f;
    private float _horizontalMove;
    private bool _isRight = true;

    private Quaternion _rotationRight;
    private Quaternion _rotationLeft;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rotationRight = Quaternion.identity;
        _rotationLeft = Quaternion.Euler(0, 180, 0);
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

        if (direction < 0 && _isRight)
        {
            Flip();
        }
        else if (direction > 0 && !_isRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isRight = !_isRight;
        transform.rotation = _isRight ? _rotationRight : _rotationLeft;
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
