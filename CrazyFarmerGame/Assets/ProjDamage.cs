using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ProjDamage : MonoBehaviour
{
    MonoBehaviour Controller;
    MonoBehaviour Seeker;
    public ScoreManager sm;
    public int ScoreToAdd = 1;
    public HealthBarScript healthBar;
    public EnemyHealth enemyHealth;

    public void SetManager(GameObject obj)
    {
        if (obj != null)
        {
            Transform scoreMTransform = obj.transform.Find("ScoreM");

            if (scoreMTransform != null)
            {
                sm = scoreMTransform.GetComponent<ScoreManager>();
            }
        }
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
                Debug.Log(enemyHealth.health);
                if (enemyHealth.health <= 0)
                {
                    Die();
                }
            }
        }
        // Existing eagle touch code
        if (Seeker != null && collision.CompareTag("Projectile"))
        {
            sm.AddScore(ScoreToAdd);
            Debug.Log("Touched eagle!");
            Controller.enabled = false;
            Seeker.enabled = false;
            Destroy(this.gameObject);
        }
    }

    private void Die()
    {
        
        sm.AddScore(ScoreToAdd);
        Vector3 movement = new Vector3(UnityEngine.Random.Range(40, 70), UnityEngine.Random.Range(-40, 40), 0f);
        this.gameObject.transform.position = this.gameObject.transform.position + movement * Time.deltaTime;
        this.gameObject.GetComponentInParent<Collider2D>().enabled = false;
        transform.Find("ProjDamage").GetComponent<Collider2D>().enabled = false;
        transform.Find("HeadCheck").GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponentInParent<SpriteRenderer>().flipY = true;
    }
}
