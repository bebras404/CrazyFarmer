using UnityEngine;
using System.Collections;

public class AiDamageToPlayer : MonoBehaviour
{
    private bool isTouchingPlayer = false;
    private Coroutine damageCoroutine;

    public PlayerHealth playerHealth;
    public int Damage = 10;
    public float damageInterval = 2f;

    public void SetTarget(GameObject obj)
    {
        playerHealth = obj.GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogWarning("PlayerHealth component not found on target.");
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
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(Damage);
            }

            yield return new WaitForSeconds(damageInterval);
        }
        damageCoroutine = null;
    }

    private void OnDestroy()
    {
        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }
}
