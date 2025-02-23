using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string _commandHorizontal = "Horizontal";
    private const string _commandJump = "Jump";

    public event Action AttackPressed;
    public event Action JumpPressed;
    public event Action<float> HorizontalChanged;

    private float _previousHorizontalInput = 0f;
    private int _leftMouseButton = 0;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw(_commandHorizontal);

        if (Mathf.Abs(horizontalInput - _previousHorizontalInput) > Mathf.Epsilon)
        {
            _previousHorizontalInput = horizontalInput;
            HorizontalChanged?.Invoke(horizontalInput);
        }

        if (Input.GetButtonDown(_commandJump))
        {
            JumpPressed?.Invoke();
        }

        if (Input.GetMouseButton(_leftMouseButton))
        {
            AttackPressed?.Invoke();
        }
    }
}
