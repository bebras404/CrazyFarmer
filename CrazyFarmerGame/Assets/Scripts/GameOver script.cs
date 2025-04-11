using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverscript : MonoBehaviour
{
    public GameObject player;
    private int LastKnownHealth;
    private bool isLoading = false; // Prevent multiple loads

    public void RestartButton()
    {
        SceneManager.LoadSceneAsync(3);
    }

    void Update()
    {
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            LastKnownHealth = playerHealth.health;
        }

        if (LastKnownHealth <= 0 && !isLoading)
        {
            isLoading = true; // Set flag to prevent multiple loads
            StartCoroutine(WaitAndLoadScene());
        }
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(2);
    }
}
