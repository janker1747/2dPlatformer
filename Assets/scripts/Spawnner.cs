using UnityEngine;

public class Spawnner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _spawnPoints;

    private float _spawnTime = 5f; 

    private void Start()
    {
        InvokeRepeating("SpawnObject", _spawnTime, _spawnTime);
    }

    private void SpawnObject()
    {
        int minValue = 0;

        int randomIndex = Random.Range(minValue, _spawnPoints.Length);
        Instantiate(_coin, _spawnPoints[randomIndex].position, _spawnPoints[randomIndex].rotation);
    }
}
