using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] levelSections; // Array of predefined level sections
    public Transform spawnPoint; // Where new sections should spawn
    public int maxSections = 10; // Limit to avoid infinite generation

    private List<GameObject> spawnedSections = new List<GameObject>();

    void Start()
    {
        // Ensure levelSections is populated
        if (levelSections.Length == 0)
        {
            Debug.LogError("No level sections assigned in the Inspector.");
            return;
        }

        // Spawn the first section manually
        SpawnSection();

        for (int i = 1; i < maxSections; i++) // Start from 1 because the first one is spawned manually
        {
            SpawnSection();
        }
    }

    void SpawnSection()
    {
        if (levelSections.Length == 0) return;

        // Pick a random section
        GameObject newSection = Instantiate(
            levelSections[Random.Range(0, levelSections.Length)],
            spawnPoint.position,
            Quaternion.identity
        );

        spawnedSections.Add(newSection);

        // Debugging: Check if the new section has been instantiated
        Debug.Log("Spawned new section: " + newSection.name);

        // Adjust spawn position based on the prefab's exit point or size
        // Look for the ExitPoint inside the new section
        Transform exitPointTransform = newSection.transform.Find("ExitPoint");

        if (exitPointTransform != null)
        {
            // If ExitPoint exists, move the spawn point to the ExitPoint position
            spawnPoint.position = exitPointTransform.position;
            Debug.Log("ExitPoint found in " + newSection.name);
        }
        else
        {
            // If ExitPoint not found, we fall back to the prefab's size
            Renderer sectionRenderer = newSection.GetComponent<Renderer>();
            if (sectionRenderer != null)
            {
                // Move spawn point to the end of the current prefab, using its bounds
                Vector3 sectionSize = sectionRenderer.bounds.size;
                spawnPoint.position = newSection.transform.position + new Vector3(0, 0, sectionSize.z); // Adjust by prefab length
            }
            Debug.LogWarning("ExitPoint not found in " + newSection.name + ", using fallback positioning.");
        }
    }
}
