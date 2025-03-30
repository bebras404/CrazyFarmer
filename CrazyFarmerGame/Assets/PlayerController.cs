using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private PlayerHealth playerHealth; // Reference to PlayerHealth script

    public GameObject fireballPrefab; // Fireball prefab
    public Transform firePoint; // Fireball spawn position

    private bool canUseInvincibility = true;
    private bool canUseFireball = true;
    private bool fireballModeActive = false;

    public float powerUpDuration = 5f;
    public float cooldownTime = 60f;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth component is missing on Player!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canUseInvincibility)
        {
            StartCoroutine(ActivateInvincibility());
        }

        if (Input.GetKeyDown(KeyCode.E) && canUseFireball)
        {
            StartCoroutine(ActivateFireballMode());
        }

        if (Input.GetMouseButtonDown(0) && fireballModeActive) // Left Mouse Click to Shoot
        {
            ShootFireball();
        }
    }

    IEnumerator ActivateInvincibility()
    {
        canUseInvincibility = false;
        playerHealth.isInvincible = true;
        Debug.Log("Invincibility Activated!");

        yield return new WaitForSeconds(powerUpDuration);

        playerHealth.isInvincible = false;
        Debug.Log("Invincibility Ended!");

        yield return new WaitForSeconds(cooldownTime - powerUpDuration);
        canUseInvincibility = true;
        Debug.Log("Invincibility Ready Again!");
    }

    IEnumerator ActivateFireballMode()
    {
        canUseFireball = false;
        fireballModeActive = true;
        Debug.Log("Fireball Mode Activated!");

        yield return new WaitForSeconds(powerUpDuration);

        fireballModeActive = false;
        Debug.Log("Fireball Mode Ended!");

        yield return new WaitForSeconds(cooldownTime - powerUpDuration);
        canUseFireball = true;
        Debug.Log("Fireball Mode Ready Again!");
    }

    void ShootFireball()
    {
        if (fireballPrefab != null && firePoint != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

            // Determine the direction (1 for right, -1 for left)
            float direction = transform.localScale.x > 0 ? 1f : -1f;

            // Set fireball direction
            fireball.GetComponent<Fireball>().SetDirection(direction);
        }
        else
        {
            Debug.LogError("Fireball Prefab or Fire Point is not assigned!");
        }
    }


}
