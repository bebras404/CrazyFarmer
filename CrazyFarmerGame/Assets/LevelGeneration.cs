using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class LevelGenerator : MonoBehaviour
{
    public GameObject firstSection;
    public GameObject[] levelSections;
    public int maxSections = 10;
    public Transform player;
    public float SpawningDistance = 30f;
    
    private List<GameObject> spawnedSections = new List<GameObject>();

    private Transform lastSectionStart; // Track the last section's starting point

    void Start()
    {
        if (firstSection == null)
        {
            Debug.LogError("First section not assigned. Make sure it's set in the Inspector.");
            return;
        }

        if (levelSections.Length == 0)
        {
            Debug.LogError("No level sections assigned in the Inspector.");
            return;
        }

        if (player == null)
        {
            Debug.LogError("Player not assigned.");
            return;
        }

        // Treat the manually placed first section as the starting point
        spawnedSections.Add(firstSection);
        lastSectionStart = firstSection.transform.Find("LevelStart");
        Debug.Log("First section added to list: " + firstSection.name);

        // Pre-spawn some sections
        for (int i = 0; i < maxSections - 1; i++)
        {
            SpawnSection();
        }
    }

    void Update()
    {
        if (spawnedSections.Count > 0)
        {
            Transform lastSectionEnd = spawnedSections[spawnedSections.Count - 1].transform.Find("LevelEnd");
            if (lastSectionEnd != null)
            {
                float distanceToEnd = Vector3.Distance(player.position, lastSectionEnd.position);

                // If player is close to the end, spawn a new section
                if (distanceToEnd < SpawningDistance)
                {
                    SpawnSection();
                }
            }
        }

        // Cleanup sections if needed
        if (spawnedSections.Count > maxSections)
        {
            GameObject firstSpawnedSection = spawnedSections[0];
            Transform firstSectionEnd = firstSpawnedSection.transform.Find("LevelEnd");
            if (firstSectionEnd != null)
            {
                float distanceToFirstSectionEnd = Vector3.Distance(player.position, firstSectionEnd.position);
                if (distanceToFirstSectionEnd >= SpawningDistance)
                {
                    Destroy(firstSpawnedSection);
                    spawnedSections.RemoveAt(0);
                    Debug.Log("Removed old section to maintain max limit.");
                }
            }
        }
    }

    void SpawnSection()
    {
        if (levelSections.Length == 0) return;

        GameObject newSection = Instantiate(
            levelSections[Random.Range(0, levelSections.Length)]
        );

        if (spawnedSections.Count > 0)
        {
            Transform lastSectionEnd = spawnedSections[spawnedSections.Count - 1].transform.Find("LevelEnd");
            Transform newSectionStart = newSection.transform.Find("LevelStart");

            

            if (lastSectionEnd != null && newSectionStart != null)
            {
                Vector3 offset = newSectionStart.position - newSection.transform.position;

                // Align X and Z, keep Y consistent
                newSection.transform.position = new Vector3(
                    lastSectionEnd.position.x - offset.x,
                    spawnedSections[spawnedSections.Count - 1].transform.position.y,
                    lastSectionEnd.position.z - offset.z
                );

                // Update lastSectionStart to the new section's start
                lastSectionStart = newSectionStart;
            }
            else
            {
                Debug.LogWarning("Missing LevelStart or LevelEnd in section.");
            }
        }

        spawnedSections.Add(newSection);
        Debug.Log("Spawned new section: " + newSection.name);
    }
}
