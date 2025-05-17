using Pathfinding;
using UnityEditor;
using UnityEngine;

public class AIDamageDealing : MonoBehaviour
{
    GameObject Enemy;
    public ScoreManager sm;
    public int ScoreToAdd = 1;
    public HealthBarScript healthBar;
    public EnemyHealth enemyHealth;
    public float DamageFromPlayer = 5f;


    private void Awake()
    {
        
    }

    void Start()
    {      
             
        Enemy = this.gameObject;
    }

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


    // This is just the relevant modified part of your AIDamageDealing script
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Projectile")) 
        {
            
            enemyHealth.TakeDamageFromPlayer(DamageFromPlayer);
            healthBar.UpdateHealthBar(enemyHealth.health, enemyHealth.maxHealth);
            if (enemyHealth.health <= 0)
            {
                Die();
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


        Enemy.GetComponent<SpriteRenderer>().flipY = true;
        Vector3 movement = new Vector3(UnityEngine.Random.Range(40, 70), UnityEngine.Random.Range(-40, 40), 0f);
        Enemy.transform.position = Enemy.transform.position + movement * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
