using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectilePrefab;
    public GameObject meleePrefab;

    // Attack mode system
    private enum AttackMode { Ranged = 0, Melee = 1 }
    private AttackMode currentAttackMode = AttackMode.Ranged;
    private KeyCode modeSwitchKey = KeyCode.Q; // Change this to your preferred key

    // Reference to your movement script
    private PlayerMovement playerMovement;

    // Cooldown variables
    private float attackCooldown = 0.5f;
    private float lastAttackTime = 0f;
    public float fireballDelay = 0.2f;
    public float meleeDelay = 0.1f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Handle attack mode switching
        if (Input.GetKeyDown(modeSwitchKey))
        {
            CycleAttackMode();
            Debug.Log("Switched to: " + currentAttackMode);
        }

        // Handle attack input
        if (Input.GetMouseButtonDown(0) && Time.time > lastAttackTime + attackCooldown && playerMovement.IsGrounded())
        {
            playerMovement.StartAttack();
            lastAttackTime = Time.time;

            // Invoke the appropriate attack based on current mode
            switch (currentAttackMode)
            {
                case AttackMode.Ranged:
                    Invoke("Shoot", fireballDelay);
                    break;
                case AttackMode.Melee:
                    Invoke("Melee", meleeDelay);
                    break;
            }
        }
    }

    void CycleAttackMode()
    {
        // Cycle through attack modes numerically
        int nextMode = ((int)currentAttackMode + 1) % System.Enum.GetValues(typeof(AttackMode)).Length;
        currentAttackMode = (AttackMode)nextMode;
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(
            projectilePrefab,
            firePosition.position,
            Quaternion.identity
        );

        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.SetDirection(playerMovement.IsFacingRight() ? 1 : -1);
        }
    }

    void Melee()
    {
        GameObject meleeAttack = Instantiate(
            meleePrefab,
            firePosition.position,
            Quaternion.identity
        );

        Projectile meleeScript = meleeAttack.GetComponent<Projectile>();
        if (meleeScript != null)
        {
            meleeScript.SetDirection(playerMovement.IsFacingRight() ? 1 : -1);
        }
    }

    // Optional: Visual feedback for current mode
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), $"Attack Mode: {currentAttackMode}");
    }
}