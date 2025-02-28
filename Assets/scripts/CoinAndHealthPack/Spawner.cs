using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _spawnPoints;

    private float _spawnTime = 5f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        WaitForSeconds _delay = new WaitForSeconds(_spawnTime);

        while (enabled)
        {
            yield return _delay;
            SpawnCoin();
        }
    }

    private void OnCoinCollected(Coin coin)
    {
        Destroy(coin.gameObject); 
    }   

    private void SpawnCoin()
    {
        float radius = 0.1f;
        int spawnIndex = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[spawnIndex];
        Collider2D existingCoin = Physics2D.OverlapCircle(spawnPoint.position, radius, LayerMask.GetMask("Default"));

        if (existingCoin == null)
        {
           Coin clonCoin =  Instantiate(_coin, spawnPoint.position, spawnPoint.rotation);
           clonCoin.Collect += OnCoinCollected;
        }
    }
}
