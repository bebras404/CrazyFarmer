using UnityEngine;
using System.Collections;

public class AiDamageToPlayer : MonoBehaviour
{

    private bool isTouchingPlayer = false;
    private Coroutine damageCoroutine;
    public PlayerHealth playerHealth;
    public int Damage = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore collisions with the head layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Head"))
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
            playerHealth.TakeDamage(Damage);

            yield return new WaitForSeconds(2f);
        }
        damageCoroutine = null;
    }

}
