using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 5f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    public PlayerHealth playerHealth;
    private bool isPlayerAlive = true;

    [SerializeField] private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerStatus();
        if (isPlayerAlive)
        {
            Vector3 targetPostition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPostition, ref velocity, smoothTime);
        }
    }

    private void CheckPlayerStatus()
    {
        if (playerHealth.health <= 0)
        {
            isPlayerAlive = false;
        }
    }
}
