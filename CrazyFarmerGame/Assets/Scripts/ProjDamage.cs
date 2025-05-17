using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ProjDamage : MonoBehaviour
{
    private ScoreManager sm;
    public int ScoreToAdd = 1;
    public HealthBarScript healthBar;
    public EnemyHealth enemyHealth;


    public void SetManager(GameObject obj)
    {
        sm = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Projectile"))
        {
            Projectile projectile = collision.GetComponent<Projectile>();
            if (projectile != null)
            {
                enemyHealth.TakeDamageFromPlayer(projectile.damage);
                healthBar.UpdateHealthBar(enemyHealth.health, enemyHealth.maxHealth);
                if (enemyHealth.health <= 0)
                {
                    Die();
                }
            }
        }

    }

    private void Die()
    {
        sm.AddScore(ScoreToAdd);
        if (gameObject.CompareTag("FAi"))
        {
            GetComponent<FlyingAIController>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 5;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<AiController>().enabled = false;
        }


        gameObject.GetComponent<SpriteRenderer>().flipY = true;
        Vector3 movement = new Vector3(UnityEngine.Random.Range(40, 70), UnityEngine.Random.Range(-40, 40), 0f);
        gameObject.transform.position = gameObject.transform.position + movement * Time.deltaTime;

    }
}
