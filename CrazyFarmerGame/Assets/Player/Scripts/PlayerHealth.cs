using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int MaxHealth = 10;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = MaxHealth;
    }

    public void TakeDamage(int amount) 
    {

        health = health - amount;
        if (health <= 0) 
        {
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
