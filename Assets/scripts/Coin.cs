using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Knight>(out Knight knight))
        {
            Destroy(gameObject);
        }
    }
}
