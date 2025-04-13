using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int MaxHealth = 10;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;
    public SaveManager sm;

    public bool isInvincible = false; // Controls invincibility

    void Start()
    {
        health = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return; // Prevent damage if invincible

        health -= amount;
        Debug.Log("Player took damage! Health: " + health);
        
        if (health <= 0)
        {            
            Debug.Log("Player died!");
            playerSr.enabled = false;
            playerMovement.enabled = false;
            
        }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > MaxHealth)
        {
            health = MaxHealth;
        }
        Debug.Log("Player healed! Health: " + health);
    }
}
