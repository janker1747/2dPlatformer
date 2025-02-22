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
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        int spawnIndex = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[spawnIndex];

        Instantiate(_coin, spawnPoint.position, spawnPoint.rotation);
    }
}
