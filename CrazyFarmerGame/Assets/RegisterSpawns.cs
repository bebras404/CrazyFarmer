using UnityEngine;

public class LevelBlock : MonoBehaviour
{
    public Transform[] spawnPoints; // Assign spawn points inside the prefab

    void Start()
    {
        SpawnAssets spawner = FindFirstObjectByType<SpawnAssets>();
        if (spawner != null)
        {
            spawner.RegisterSpawnPoints(spawnPoints);
        }
    }
}
