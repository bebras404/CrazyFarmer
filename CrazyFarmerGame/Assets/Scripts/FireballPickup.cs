using UnityEngine;

public class FireballPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController pc = collision.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.UnlockFireball();
                Destroy(gameObject);
            }
        }
    }
}