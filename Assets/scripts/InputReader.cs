using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpPressed;
    public event Action<float> HorizontalChanged;

    private const string _�ommandHorizontal = "Horizontal";
    private const string _�ommandJump = "Jump";

    private float _previousHorizontalInput = 0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw(_�ommandHorizontal);

        if (Mathf.Abs(horizontalInput - _previousHorizontalInput) > Mathf.Epsilon)
        {
            _previousHorizontalInput = horizontalInput;
            HorizontalChanged?.Invoke(horizontalInput);
        }

        if (Input.GetButtonDown(_�ommandJump))
        {
            JumpPressed?.Invoke();
        }
    }
}
