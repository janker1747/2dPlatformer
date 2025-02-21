using System.Collections;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _spawnPoints;

    private float _spawnTime = 5f; 

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        WaitForSeconds _delay = new WaitForSeconds(_spawnTime);

        while (true)
        {
            yield return _delay;
            CreateObject();
        }
    }

    private void CreateObject()
    {
        int spawnIndex = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[spawnIndex];

        Instantiate(_coin, spawnPoint.position, spawnPoint.rotation);
    }
}
