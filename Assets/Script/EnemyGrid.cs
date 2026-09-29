using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private float spawnDistance = 0.5f;

    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = transform.position + Vector3.left * (i * spawnDistance);

            GameObject enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);

            _enemies.Add(enemy);
        }
    }
}
