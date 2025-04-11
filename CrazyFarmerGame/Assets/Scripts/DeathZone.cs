using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public int instantKillDamage = 1000; // High enough to guarantee death

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Deal massive damage to ensure death
                playerHealth.TakeDamage(instantKillDamage);
            }
        }
    }
}