using System.Collections;
using UnityEngine;

public class AiController : MonoBehaviour
{
    private bool isPlayerAlive = true;
    public GameObject player;
    public float speed;
    private float distance;
    private bool isFacingRight = true;
    public float range;
    public PlayerHealth playerHealth;
    private bool isTouchingPlayer = false;
    public Animator animator;
    private Rigidbody2D rb;
    private bool canMove = true;
    private bool isAttacking = false;

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
        if (player == null || playerHealth == null) return;

       
        if (playerHealth.health <= 0)
        {
            animator.SetBool("IsPlayerDead", true);
            isPlayerAlive = false;
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsTouchingPlayer", false);
            return;
        }
        else
        {
            animator.SetBool("IsPlayerDead", false);
        }

        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (isPlayerAlive && distance <= range && canMove && !isAttacking)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsTouchingPlayer", false);
            MoveTowardsPlayer();
        }
        else
        {
            animator.SetBool("IsWalking", false);

            if (isAttacking)
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                animator.SetBool("IsTouchingPlayer", true);
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        if (!canMove) return;

        Vector2 direction = (player.transform.position - transform.position).normalized;
        direction.y = 0;
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);
        Flip(direction.x);
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

            if (!isAttacking)
            {
                StartCoroutine(PerformAttack());
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }

    private IEnumerator PerformAttack()
    {
        isAttacking = true;
        canMove = false;

        while (isTouchingPlayer && playerHealth.health > 0)
        {
            animator.SetBool("IsTouchingPlayer", true);
            animator.SetBool("IsWalking", false);

            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            yield return new WaitForSeconds(0.5f);
        }
        isAttacking = false;
        canMove = true;
        animator.SetBool("IsTouchingPlayer", false);
    }

}
