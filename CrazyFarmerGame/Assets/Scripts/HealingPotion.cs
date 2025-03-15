using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int HealAmount = 2;
    public float floatSpeed = 1f;  
    public float floatHeight = 0.5f;
    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    public void SetPlayer(GameObject obj) 
    {
        playerHealth = obj.GetComponent<PlayerHealth>();     
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerHealth.Heal(HealAmount);
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
