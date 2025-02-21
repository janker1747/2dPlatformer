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

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMove = _inputReader.GetHorizontalInput() * _speed;
        _animator.SetRunning(Mathf.Abs(_horizontalMove));

        if (_horizontalMove < 0 && _isRight)
        {
            Flip();
        }
        else if (_horizontalMove > 0 && !_isRight)
        {
            Flip();
        }

        Jump();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(_horizontalMove, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;
    }

    private void Flip()
    {
        _isRight = !_isRight;
        transform.rotation = Quaternion.Euler(0, _isRight ? 0 : 180, 0);
    }

    private void Jump()
    {
        if (_groundChecker.IsGrounded() && _inputReader.IsJumpPressed()) 
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
