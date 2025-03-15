using UnityEngine;


public class AiController : MonoBehaviour
{
    private bool isPlayerAlive = true;
    public GameObject player;
    public float speed;
    private float distance;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    private bool isFacingRight = true;
    public float range;
    public PlayerHealth playerHealth;
    private bool isTouchingPlayer = false;

    


    public Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

        if (player == null)
        {
            Debug.LogError("AiController: Player is not assigned! Make sure LevelBlock sets it.");
        }
    }
    public void SetTarget(GameObject playerObj)
    {
        this.player = playerObj;
        playerHealth = playerObj.GetComponent<PlayerHealth>();
    }


    void Update()
    {
        
        if (isTouchingPlayer)
        {
            animator.SetBool("IsTouchingPlayer", true);

        }
        else if (!isTouchingPlayer)
        {
            animator.SetBool("IsTouchingPlayer", false);
        }
        if (playerHealth.health <= 0)
        {
            animator.SetBool("IsPlayerDead", true);
        }
        else if (playerHealth.health > 0) 
        {
            animator.SetBool("IsPlayerDead", false);
        }

            CheckPlayerStatus();

        if (transform.position.y < -15)
        {
            Destroy(this.gameObject);
        }

        if (isPlayerAlive)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance <= range)
            {
                animator.SetBool("IsWalking", true);
                MoveTowardsPlayer();
            }
            else if(distance > range)
            {
                animator.SetBool("IsWalking", false);
                StopMovement();
            }
        }
    }

    private void MoveTowardsPlayer()
    {       
        Vector2 direction = (player.transform.position - transform.position).normalized;
        direction.y = 0;
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);
        Flip(direction.x);
    }

    private void StopMovement() 
    {
        rb.linearVelocity = new Vector2(0, 0);
    }

    private void Flip(float moveDirection)
    {
        if (moveDirection > 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            isTouchingPlayer = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }

    private void CheckPlayerStatus()
    {
        if (playerHealth.health <= 0)
        {
            
            isPlayerAlive = false;
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Stop moving when player is dead
        }
    }

   
}
