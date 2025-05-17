using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private PlayerHealth playerHealth; // Reference to PlayerHealth script

    public GameObject fireballPrefab; // Fireball prefab
    public Transform firePoint; // Fireball spawn position

    public TextMeshProUGUI fireballCooldownText; // UI Text for Fireball cooldown
    public TextMeshProUGUI invincibilityCooldownText; // UI Text for Invincibility cooldown

    private bool canUseInvincibility = true;
    private bool canUseFireball = true;
    private bool fireballModeActive = false;

    public float powerUpDuration = 5f;
    public float cooldownTime = 60f;

    private float fireballCooldownTimer = 0f;
    private float invincibilityCooldownTimer = 0f;

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

        UpdateCooldownUI();
    }

    IEnumerator ActivateInvincibility()
    {
        canUseInvincibility = false;
        playerHealth.isInvincible = true;
        invincibilityCooldownTimer = cooldownTime;
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
        fireballCooldownTimer = cooldownTime;
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

            float direction = transform.localScale.x > 0 ? 1f : -1f;

            fireball.GetComponent<Fireball>().SetDirection(direction);
        }
        else
        {
            Debug.LogError("Fireball Prefab or Fire Point is not assigned!");
        }
    }

    void UpdateCooldownUI()
    {
        if (!canUseFireball)
        {
            fireballCooldownTimer -= Time.deltaTime;
            fireballCooldownTimer = Mathf.Max(fireballCooldownTimer, 0f);
            fireballCooldownText.text = "Fireball: " + Mathf.Ceil(fireballCooldownTimer).ToString() + "s";
        }
        else
        {
            fireballCooldownText.text = "Fireball: Ready!";
        }

        if (!canUseInvincibility)
        {
            invincibilityCooldownTimer -= Time.deltaTime;
            invincibilityCooldownTimer = Mathf.Max(invincibilityCooldownTimer, 0f);
            invincibilityCooldownText.text = "Invincibility: " + Mathf.Ceil(invincibilityCooldownTimer).ToString() + "s";
        }
        else
        {
            invincibilityCooldownText.text = "Invincibility: Ready!";
        }
    }
}
