using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    public float maxHealth = 10;
    public float health;


    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamageFromPlayer(float amount) 
    {
        health -= amount;
    }

    private void Update()
    {
        

    }

}
