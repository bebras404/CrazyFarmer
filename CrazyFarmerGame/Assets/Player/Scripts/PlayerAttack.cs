using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectilePrefab;

    // Reference to your movement script
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
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