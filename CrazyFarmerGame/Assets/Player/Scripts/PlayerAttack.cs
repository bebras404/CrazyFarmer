using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectilePrefab;

    // Reference to your movement script
    private PlayerMovement playerMovement;

    // Shooting cooldown variables
    private float attackCooldown = 0.5f;
    private float lastAttackTime = 0f;

    // Delay between attack animation start and actual projectile firing
    public float fireballDelay = 0.2f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Check for attack input, cooldown, and grounded status
        if (Input.GetMouseButtonDown(0) && Time.time > lastAttackTime + attackCooldown && playerMovement.IsGrounded())
        {
            // Start the attack animation through the movement script
            playerMovement.StartAttack();

            // Schedule the actual projectile firing after a delay
            Invoke("Shoot", fireballDelay);

            lastAttackTime = Time.time;
        }
    }

    void Shoot()
    {

        // Create the projectile
        GameObject projectile = Instantiate(
            projectilePrefab,
            firePosition.position,
            Quaternion.identity
        );

        // Get the Projectile component
        Projectile projectileScript = projectile.GetComponent<Projectile>();

        // Set direction based on player's facing direction
        if (projectileScript != null)
        {
            projectileScript.SetDirection(playerMovement.IsFacingRight() ? 1 : -1);
        }
    }
}