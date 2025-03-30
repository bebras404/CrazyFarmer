using Pathfinding;
using UnityEditor;
using UnityEngine;

public class AIDamageDealing : MonoBehaviour
{
    GameObject Enemy;
    MonoBehaviour Controller;
    MonoBehaviour Seeker;
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
        enemyHealth = GetComponentInParent<EnemyHealth>();      
        Enemy = gameObject.transform.parent.gameObject;
        if (Enemy.GetComponent<AiController>() != null)
        {
            Controller = Enemy.GetComponent<AiController>();
        }
        else 
        {
            Controller = Enemy.GetComponent<FlyingAIController>();
            Seeker = Enemy.GetComponent<Seeker>();
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (Seeker != null && collision.gameObject.CompareTag("Player")) 
        {
            sm.AddScore(ScoreToAdd);
            Debug.Log("Touched eagle!");
            Controller.enabled = false;
            Seeker.enabled = false;
            Destroy(Enemy);
        }        
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyHealth.TakeDamageFromPlayer(DamageFromPlayer);
            Debug.Log(enemyHealth.health);
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
        GetComponentInParent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Enemy.GetComponent<SpriteRenderer>().flipY = true;
        Enemy.GetComponent<Collider2D>().enabled = false;
        Vector3 movement = new Vector3(UnityEngine.Random.Range(40, 70), UnityEngine.Random.Range(-40, 40), 0f);
        Enemy.transform.position = Enemy.transform.position + movement * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
