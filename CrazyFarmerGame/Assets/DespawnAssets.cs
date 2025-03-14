using UnityEngine;

public class DespawnOnDistance : MonoBehaviour
{
    public string[] tagsToCheck; 
    public float despawnDistance = 300f;
    private Transform playerTransform; 

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform; // Assumes player has the "Player" tag
    }

    void Update()
    {
        foreach (string tag in tagsToCheck)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objects)
            {
                if (Vector2.Distance(playerTransform.position, obj.transform.position) > despawnDistance)
                {
                    Destroy(obj);
                }
            }
        }
    }
}
