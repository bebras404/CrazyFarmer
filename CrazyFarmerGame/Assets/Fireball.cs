using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;
    private float direction;
    public int damage = 1; // Fireball damage amount

    public void SetDirection(float dir)
    {
        direction = dir;
        transform.localScale = new Vector3(dir, 1f, 1f); // Flip sprite if needed
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the fireball hits an enemy
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.health -= damage; // Reduce enemy health
            if (enemyHealth.health <= 0)
            {
                Destroy(collision.gameObject); // Destroy the enemy if health is 0
            }
            Destroy(gameObject); // Destroy fireball on impact
        }
    }
}
