using UnityEngine;

public class CollectableScore : MonoBehaviour
{
    public ScoreManager sm;
    public int ScoreToAdd = 200;
    public float floatSpeed = 0;
    public float floatHeight = 0;
    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        GameObject go = GameObject.Find("PlayerUI");
        sm = go.GetComponentInChildren<ScoreManager>();
    }

    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            sm.AddScore(ScoreToAdd);
        }
        Destroy(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
