using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem.XR;
using System;

public class SpawnAssets : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Assign your 3 enemy prefabs in the Inspector
    public Transform[] spawnPoints;   // Assign spawn points in the LevelBlock
    public float spawnDelay = 1.0f;   // Time between spawns
    public float SpawnRangeFar = 60f;
    public float SpawnRangeClose = 30f;
    private float DistanceToPlayer;
    private GameObject UIcanvas;
    private AIDamageDealing Playerdmg;
    public GameObject fireballPickupPrefab; // Your fireball power-up prefab
    public float fireballSpawnChance = 0.2f; // 20% chance to spawn a fireball instead of enemy

    private List<Transform> availableSpawnPoints;
    private GameObject player;

    private void Start()
    {
        // Find the PlayerHealth component in the scene
        player = GameObject.FindWithTag("Player");

        UIcanvas = GameObject.FindWithTag("UI");
        //Debug.Log(UIcanvas != null);
        availableSpawnPoints = new List<Transform>(spawnPoints);

        if (availableSpawnPoints.Count > 0 && enemyPrefabs.Length > 0)
        {
            InvokeRepeating(nameof(SpawnEnemy), 0f, spawnDelay);
        }
        else
        {
            Debug.LogWarning("No spawn points or enemy prefabs assigned!");
        }


        
        
    }

    private void Update()
    {

    }

    void SpawnEnemy()
    {
        if (availableSpawnPoints.Count == 0)
        {
            Debug.Log("All spawn points are used up. Stopping spawner.");
            CancelInvoke(nameof(SpawnEnemy));
            return;
        }

        int index = UnityEngine.Random.Range(0, availableSpawnPoints.Count);
        Transform spawnPoint = availableSpawnPoints[index];
        DistanceToPlayer = Vector2.Distance(spawnPoint.position, player.transform.position);

        if (DistanceToPlayer <= SpawnRangeFar && DistanceToPlayer >= SpawnRangeClose)
        {
            GameObject newSpawned;

            // 🔀 Random chance to spawn fireball pickup instead of enemy
            if (fireballPickupPrefab != null && UnityEngine.Random.value < fireballSpawnChance)
            {
                newSpawned = Instantiate(fireballPickupPrefab, spawnPoint.position, Quaternion.identity);
                Debug.Log("Spawned fireball power-up.");
            }
            else
            {
                GameObject enemyPrefab = enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)];
                newSpawned = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            }

            // Shared setup for all spawned objects
            if (newSpawned.GetComponent<CoinScript>() != null)
            {
                CoinScript cs = newSpawned.GetComponent<CoinScript>();
                CoinManager cm = GameObject.Find("GameManager").GetComponent<CoinManager>();
                cs.SetCM(cm);
            }

            if (newSpawned.GetComponent<ProjDamage>() != null)
            {
                newSpawned.GetComponent<ProjDamage>().SetManager(UIcanvas);
            }

            if (newSpawned.GetComponent<AiController>() != null)
            {
                newSpawned.GetComponent<AiController>().SetTarget(player);
            }

            if (newSpawned.GetComponent<AiDamageToPlayer>() != null)
            {
                newSpawned.GetComponent<AiDamageToPlayer>().SetTarget(player);
            }

            if (newSpawned.GetComponent<FlyingAIController>() != null)
            {
                newSpawned.GetComponent<FlyingAIController>().SetPlayer(player);
            }

            if (newSpawned.GetComponent<HealingPotion>() != null)
            {
                newSpawned.GetComponent<HealingPotion>().SetPlayer(player);
            }

            availableSpawnPoints.RemoveAt(index);
        }
    }

}
