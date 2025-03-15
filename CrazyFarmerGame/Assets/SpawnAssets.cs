using UnityEngine;
using System.Collections.Generic;

public class SpawnAssets : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform player;
    public float spawnInterval = 3f;
    public int maxEnemies = 10;
    public float minSpawnDistance = 5f;
    public float maxSpawnDistance = 15f;

    private int currentEnemyCount = 0;
    private List<Transform> spawnPoints = new List<Transform>(); // Dynamic list of spawn points

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    public void RegisterSpawnPoints(Transform[] newSpawnPoints)
    {
        spawnPoints.AddRange(newSpawnPoints);
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount >= maxEnemies || spawnPoints.Count == 0 || enemyPrefabs.Length == 0) return;

        // Find a valid spawn point
        Transform validSpawnPoint = null;
        foreach (Transform spawnPoint in spawnPoints)
        {
            float distance = Vector2.Distance(player.position, spawnPoint.position);
            if (distance >= minSpawnDistance && distance <= maxSpawnDistance)
            {
                validSpawnPoint = spawnPoint;
                break;
            }
        }

        if (validSpawnPoint == null) return;

        // Select a random enemy prefab
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Spawn the enemy at the chosen point
        Instantiate(enemyToSpawn, validSpawnPoint.position, Quaternion.identity);
        currentEnemyCount++;
    }

    public void EnemyDestroyed()
    {
        currentEnemyCount--;
    }
}
