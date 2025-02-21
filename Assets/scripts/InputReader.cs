using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpPressed;
    public event Action<float> HorizontalChanged;

    private const string _ñommandHorizontal = "Horizontal";
    private const string _ñommandJump = "Jump";

    private float _previousHorizontalInput = 0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw(_ñommandHorizontal);

        if (Mathf.Abs(horizontalInput - _previousHorizontalInput) > Mathf.Epsilon)
        {
            _previousHorizontalInput = horizontalInput;
            HorizontalChanged?.Invoke(horizontalInput);
        }

        if (Input.GetButtonDown(_ñommandJump))
        {
            JumpPressed?.Invoke();
        }
    }
}
