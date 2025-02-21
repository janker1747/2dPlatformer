using UnityEngine;

public class InputReader : MonoBehaviour
{  
    private const string CommandHorizontal = "Horizontal";
    private const string CommandJump = "Jump";

    public float GetHorizontalInput()
    {

        return Input.GetAxisRaw(CommandHorizontal);
    }

    public bool IsJumpPressed()
    {
        return Input.GetButtonDown(CommandJump);
    }
}
