using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Coin _coin;
    private int _lastSpawnPointIndex = 1;

    private void OnEnable()
    {
        _coin.PickedUp += TranslateCoin;
    }

    private void OnDisable()
    {
        _coin.PickedUp -= TranslateCoin;
    }

    private void TranslateCoin()
    {
        int indexSpawnPoint = Random.Range(0, _spawnPoints.Count);

        if (indexSpawnPoint == _lastSpawnPointIndex)
        {
            while (indexSpawnPoint == _lastSpawnPointIndex)
            {
                indexSpawnPoint = Random.Range(0, _spawnPoints.Count);
            }
        }

        _coin.transform.position = _spawnPoints[indexSpawnPoint].position;
        _lastSpawnPointIndex = indexSpawnPoint;
    }
}
