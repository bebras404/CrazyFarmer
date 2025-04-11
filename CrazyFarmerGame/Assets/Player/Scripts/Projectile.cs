using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f;
    public float lifetime = 2f;
    public float damage = 5f; // Added damage value
    private int direction = 1;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(projectileSpeed * direction, 0);

        if (direction < 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }

        Destroy(gameObject, lifetime);
    }

    public void SetDirection(int dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Deal damage to enemy
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamageFromPlayer(damage);
            }
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}