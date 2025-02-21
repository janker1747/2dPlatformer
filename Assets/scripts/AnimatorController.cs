using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;
    private int _speedHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _speedHash = Animator.StringToHash("speed");
    }

    public void SetRunning(float speed)
    {
        _animator.SetFloat(_speedHash, Mathf.Abs(speed));
    }
}
