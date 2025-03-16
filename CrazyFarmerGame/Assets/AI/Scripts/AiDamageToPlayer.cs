using UnityEngine;
using System.Collections;

public class AiDamageToPlayer : MonoBehaviour
{
    private bool isTouchingPlayer = false;
    private Coroutine damageCoroutine;
    public PlayerHealth playerHealth;
    public int Damage = 0;
    public ScoreManager sm;
    public int Score = 0;


    public void SetTarget(GameObject obj)
    {
        playerHealth = obj.GetComponent<PlayerHealth>();
    }

    public void SetManager(GameObject obj) 
    {
        sm = obj.GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("HeadCheckAI"))
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
        
        
            isTouchingPlayer = false;

            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
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

            yield return new WaitForSeconds(2f);
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
