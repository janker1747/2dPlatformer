using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    private float _chaseSpeed;
    private Patroller _patroller;
    private Flipper _flipper;
    private Rigidbody2D _rigidbody;
    private Transform _target;
    private bool _isChasing;

    public void Initialize(float chaseSpeed, Patroller patroller, Flipper flipper)
    {
        _chaseSpeed = chaseSpeed;
        _patroller = patroller;
        _flipper = flipper;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void StartChasing(Transform target)
    {
        _target = target;
        _isChasing = true;
    }

    public void StopChasing()
    {
        _target = null;
        _isChasing = false;
        _rigidbody.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (_isChasing && _target != null)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    private void Chase()
    {
        Vector2 direction = (_target.position - transform.position).normalized;
        _rigidbody.velocity = direction * _chaseSpeed;

        _flipper?.Flip(direction.x);
    }

    private void Patrol()
    {
        _patroller?.Move(transform);
    }
}
