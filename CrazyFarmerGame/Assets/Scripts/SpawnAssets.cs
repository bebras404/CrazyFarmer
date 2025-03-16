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

    private List<Transform> availableSpawnPoints;
    private GameObject player;

    private void Start()
    {
        // Find the PlayerHealth component in the scene
        player = GameObject.FindWithTag("Player");
        UIcanvas = GameObject.FindWithTag("UI");

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

        // Pick a random available spawn point
        int index = UnityEngine.Random.Range(0, availableSpawnPoints.Count);
        Transform spawnPoint = availableSpawnPoints[index];
        DistanceToPlayer = Vector2.Distance(spawnPoint.position, player.transform.position);
        if (DistanceToPlayer <= SpawnRangeFar && DistanceToPlayer >= SpawnRangeClose)
        {
            // Pick a random enemy type
            GameObject enemyPrefab = enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)];

            // Instantiate enemy at spawn point
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Assign PlayerHealth to the AIController.

            

            if (newEnemy.GetComponent<AiController>() != null)
            {
                AiController aiController = newEnemy.GetComponent<AiController>();
                aiController.SetTarget(player);
            }

            if (newEnemy.GetComponent<AiDamageToPlayer>() != null)
            {
                AiDamageToPlayer damageScript = newEnemy.GetComponent<AiDamageToPlayer>();
                if (UIcanvas.GetComponent<ScoreManager>() != null)
                {
                    damageScript.SetManager(UIcanvas);
                }
                damageScript.SetTarget(player);
            }

            if (newEnemy.GetComponent<FlyingAIController>() != null)
            {
                FlyingAIController Fcontroller = newEnemy.GetComponent<FlyingAIController>();
                Fcontroller.SetPlayer(player);
            }

            if (newEnemy.GetComponent<HealingPotion>() != null)
            {
                HealingPotion hp = newEnemy.GetComponent<HealingPotion>();
                hp.SetPlayer(player);
            }



            // Remove the used spawn point from the list
            availableSpawnPoints.RemoveAt(index);
        }
    }
}
