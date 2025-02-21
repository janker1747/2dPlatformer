using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _minDistance = 0.1f;
    [SerializeField] private Animator _animator;

    private bool _isFacingRight = true;
    private int _currentWaypointIndex = 0;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, _speed * Time.deltaTime);
        _animator.SetFloat("speed", Mathf.Abs(transform.position.x));

        if ((transform.position - _waypoints[_currentWaypointIndex].position).sqrMagnitude < _minDistance * _minDistance)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }

        if ((_waypoints[_currentWaypointIndex].position.x > transform.position.x && !_isFacingRight) ||
            (_waypoints[_currentWaypointIndex].position.x < transform.position.x && _isFacingRight))
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
