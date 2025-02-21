using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _minDistance = 0.1f;

    private int _currentWaypointIndex = 0;

    public void Move(Transform transform, Flipper flipper)
    {
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, _speed * Time.deltaTime);

        if ((transform.position - _waypoints[_currentWaypointIndex].position).sqrMagnitude < _minDistance * _minDistance)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }

        flipper.Flip(_waypoints[_currentWaypointIndex].position.x - transform.position.x);
    }
}