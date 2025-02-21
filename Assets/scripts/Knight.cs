using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private Rigidbody2D _rigibody;
    private float _speed = 5f; 
    private float _jumpForse = 10f;
    private float _horizontalMove;
    private bool _isRight = true;
    private bool _isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _speed;
        _animator.SetFloat("speed", Mathf.Abs(_horizontalMove));
       

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
        Vector2 targetVelocity = new Vector2(_horizontalMove, _rigibody.velocity.y);
        _rigibody.velocity = targetVelocity;
    }

    private void Flip()
    {
        _isRight = !_isRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Jump()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigibody.AddForce(transform.up * _jumpForse, ForceMode2D.Impulse);
        }
    }
}
