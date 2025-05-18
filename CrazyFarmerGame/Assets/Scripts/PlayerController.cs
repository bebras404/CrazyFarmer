using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private PlayerHealth playerHealth;

    [Header("References")]
    public GameObject fireballPrefab;
    public Transform firePoint;
    public TextMeshProUGUI fireballCooldownText;
    public TextMeshProUGUI invincibilityCooldownText;

    // --- State flags ---
    private bool canUseInvincibility = true;
    private bool canUseFireball = false; // locked until pickup
    private bool fireballModeActive = false;

    [Header("Timings")]
    public float powerUpDuration = 5f;    // how long each power‐up lasts
    public float cooldownTime = 60f;   // invincibility cooldown

    private float fireballActiveTimer = 0f;
    private float invincibilityCooldownTimer = 0f;

    void Start()
    {
        // grab your health component
        playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth == null)
            Debug.LogError("PlayerHealth component is missing on Player!");
    }

    void Update()
    {
        // — INVINCIBILITY (Q) —
        if (Input.GetKeyDown(KeyCode.Q) && canUseInvincibility)
            StartCoroutine(ActivateInvincibility());

        // — FIREBALL MODE (E) —
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!canUseFireball)
            {
                Debug.Log("Fireball is locked! Pick up the power‐up in the world first.");
            }
            else if (!fireballModeActive)
            {
                StartCoroutine(ActivateFireballMode());
            }
        }

        // — SHOOT FIREBALL (Left‐click) —
        if (Input.GetMouseButtonDown(0) && fireballModeActive)
            ShootFireball();

        UpdateCooldownUI();
    }

    IEnumerator ActivateInvincibility()
    {
        canUseInvincibility = false;
        playerHealth.isInvincible = true;
        invincibilityCooldownTimer = cooldownTime;
        Debug.Log("Invincibility Activated!");

        // active window
        yield return new WaitForSeconds(powerUpDuration);

        playerHealth.isInvincible = false;
        Debug.Log("Invincibility Ended!");

        // cooldown before you can Q again
        yield return new WaitForSeconds(cooldownTime - powerUpDuration);
        canUseInvincibility = true;
        Debug.Log("Invincibility Ready Again!");
    }

    IEnumerator ActivateFireballMode()
    {
        // consume your pickup
        canUseFireball = false;
        fireballModeActive = true;
        fireballActiveTimer = powerUpDuration;
        Debug.Log("Fireball Mode Activated!");

        // active window
        yield return new WaitForSeconds(powerUpDuration);

        fireballModeActive = false;
        Debug.Log("Fireball Mode Ended! You must pick up another one to use it again.");
        // no re‐enable here — locked until next pickup
    }

    void ShootFireball()
    {
        if (fireballPrefab == null || firePoint == null)
        {
            Debug.LogError("Cannot shoot: assign fireballPrefab and firePoint in the Inspector!");
            return;
        }

        var fb = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        float dir = transform.localScale.x > 0 ? 1f : -1f;
        fb.GetComponent<Fireball>().SetDirection(dir);
    }

    void UpdateCooldownUI()
    {
        // Fireball UI
        if (fireballCooldownText != null)
        {
            if (fireballModeActive)
            {
                fireballActiveTimer -= Time.deltaTime;
                fireballActiveTimer = Mathf.Max(fireballActiveTimer, 0f);
                fireballCooldownText.text = "Fireball: Active " + Mathf.Ceil(fireballActiveTimer) + "s";
            }
            else if (canUseFireball)
            {
                fireballCooldownText.text = "Fireball: Ready!";
            }
            else
            {
                fireballCooldownText.text = "Fireball: Locked!";
            }
        }

        // Invincibility UI (unchanged)
        if (invincibilityCooldownText != null)
        {
            if (!canUseInvincibility)
            {
                invincibilityCooldownTimer -= Time.deltaTime;
                invincibilityCooldownTimer = Mathf.Max(invincibilityCooldownTimer, 0f);
                invincibilityCooldownText.text = "Invincibility: " + Mathf.Ceil(invincibilityCooldownTimer) + "s";
            }
            else
            {
                invincibilityCooldownText.text = "Invincibility: Ready!";
            }
        }
    }

    /// <summary>
    /// Call this from your Pickup script (e.g. OnTriggerEnter) when the player grabs the fireball prefab.
    /// </summary>
    public void UnlockFireball()
    {
        canUseFireball = true;
        Debug.Log("Fireball Power‐Up Picked Up and Ready to Use!");
    }
}
