using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool isAttacking = false;
    private bool DoubleJump = false;

    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask EntityLayer;


    private Audiomanager audioManager;
    private float attackCooldown = 0.1f;//buvo 0.5f testuoju ar geriau zaidima jauciasi kai nera slowdown po atakinimo
    private float lastAttackTime = 0f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("SFXAudio").GetComponent<Audiomanager>();


        if (PlayerPrefs.GetInt("bought_wand", 0) == 1)
        {
            speed *= 1.5f;
        }
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && IsGrounded() && !isAttacking && !DoubleJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            audioManager.PlaySingleJumpSound();

        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
        if (Input.GetButtonDown("Jump") && !DoubleJump && !isAttacking && !IsGrounded()) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, (jumpingPower/4)*3);
            DoubleJump = true;
            audioManager.PlayDoubleJumpSound();
        }

        if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);
            DoubleJump = false;
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
        //fireball shooting animation logic
        if (Input.GetMouseButtonDown(0) && Time.time > lastAttackTime + attackCooldown && IsGrounded())
        {
            isAttacking = true;
            animator.SetBool("IsAttacking", true);
            lastAttackTime = Time.time;
        }
        else if (Time.time > lastAttackTime + attackCooldown * 0.5f)
        {
            isAttacking = false;
            animator.SetBool("IsAttacking", false);
        }

        Flip();
    }
    // Add this method to your PlayerMovement class
    public void StartAttack()
    {
        isAttacking = true;
        animator.SetBool("IsAttacking", true);
        lastAttackTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, 0.3f, EntityLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public bool IsFacingRight()
    {
        return isFacingRight;
    }
}