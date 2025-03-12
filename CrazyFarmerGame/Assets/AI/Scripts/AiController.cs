using System.Collections;
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
    public int Damage = 2;
    public PlayerHealth playerHealth;
    private bool isTouchingPlayer = false;
    private Coroutine damageCoroutine;
    public SpriteRenderer EnemySr;
    public float gravityScale = 1;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
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
                MoveTowardsPlayer();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        direction.y = 0; // Keep movement horizontal only

        // Apply velocity instead of directly changing position
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

    private void CheckPlayerStatus()
    {
        if (playerHealth.health <= 0)
        {
            isPlayerAlive = false;
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Stop moving when player is dead
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore collisions with the head layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Head"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = true;
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(DealDamage());
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;

            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }


    private IEnumerator DealDamage()
    {
        while (isTouchingPlayer)
        {
            playerHealth.TakeDamage(Damage);
            yield return new WaitForSeconds(2f);
        }

        damageCoroutine = null;
    }
}
