using UnityEngine;
using System.Collections;

public class AiController : MonoBehaviour
{
    private bool isPlayerAlive = true;
    public GameObject player;
    public float speed;
    public float distance;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    private bool isFacingRight = true;
    public float range;
    public int Damage = 2;
    public PlayerHealth playerHealth;
    private bool isTouchingPlayer = false;
    private Coroutine damageCoroutine;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckPlayerStatus();
        if (transform.position.y < -20) 
        {
            Destroy(this.gameObject);
        }
        if (isPlayerAlive)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = (player.transform.position - transform.position).normalized;
            direction.y = 0;
            if (distance <= range)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
                Flip(direction.x);
            }
        }
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
