using UnityEngine;

public class Flipper : MonoBehaviour
{
    private bool _isRight = true;
    private Quaternion _rotationRight = Quaternion.identity;
    private Quaternion _rotationLeft = Quaternion.Euler(0, 180, 0);

    public void Flip(float direction)
    {
        if (direction < 0 && _isRight)
        {
            SetRotation(false);
        }
        else if (direction > 0 && !_isRight)
        {
            SetRotation(true);
        }
    }

    private void SetRotation(bool isRight)
    {
        _isRight = isRight;
        transform.rotation = _isRight ? _rotationRight : _rotationLeft;
    }
}