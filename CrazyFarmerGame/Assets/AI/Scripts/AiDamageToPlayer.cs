using UnityEngine;
using System.Collections;

public class AiDamageToPlayer : MonoBehaviour
{
    private bool isTouchingPlayer = false;
    private Coroutine damageCoroutine;
    public PlayerHealth playerHealth;
    public int Damage = 0;
    public ScoreManager sm;
    public int ScoreToAdd = 1;


    public void SetTarget(GameObject obj)
    {
        playerHealth = obj.GetComponent<PlayerHealth>();
    }

    public void SetManager(GameObject obj)
    {
        if (obj != null)
        {
            Transform scoreMTransform = obj.transform.Find("ScoreM");

            if (scoreMTransform != null)
            {
                sm = scoreMTransform.GetComponent<ScoreManager>();
            }
            else
            {
                Debug.LogError("AiDamageToPlayer: ScoreM object not found as a child of UIcanvas!");
            }

            if (sm == null)
            {
                Debug.LogError("AiDamageToPlayer: ScoreManager script not found on ScoreM object!");
            }
        }
        else
        {
            Debug.LogError("AiDamageToPlayer: Provided GameObject is null!");
        }
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
        sm.AddScore(ScoreToAdd);
        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }
}
