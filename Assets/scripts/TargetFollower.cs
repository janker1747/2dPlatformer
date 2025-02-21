using TMPro;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 5f;
    private Vector3 _offset;

    private void Awake()
    {
        _offset = transform.position - _player.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _player.transform.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _speed);
    }
}