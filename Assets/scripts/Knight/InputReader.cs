using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string CommandHorizontal = "Horizontal";
    private const string CommandJump = "Jump";

    private float _previousHorizontalInput = 0f;
    private int _leftMouseButton = 0;

    public event Action VampirismPressed;
    public event Action AttackPressed;
    public event Action JumpPressed;
    public event Action<float> HorizontalChanged;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw(CommandHorizontal);

        if (Mathf.Abs(horizontalInput - _previousHorizontalInput) > Mathf.Epsilon)
        {
            _previousHorizontalInput = horizontalInput;
            HorizontalChanged?.Invoke(horizontalInput);
        }

        if (Input.GetButtonDown(CommandJump))
        {
            JumpPressed?.Invoke();
        }

        if (Input.GetMouseButton(_leftMouseButton))
        {
            AttackPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            VampirismPressed?.Invoke();
        }
    }
}
