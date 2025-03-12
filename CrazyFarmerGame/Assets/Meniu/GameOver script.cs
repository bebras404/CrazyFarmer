using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public GameObject player;
    private int LastKnownHealth;


    public void RestartButton()
    {
        SceneManager.LoadSceneAsync(2);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }




    // Update is called once per frame
    void Update()
    {
        if (player.gameObject != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            LastKnownHealth = playerHealth.health;

        }
        if (LastKnownHealth <= 0)
        {
            StartCoroutine(WaitAndLoadScene());
        }


    }
    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        SceneManager.LoadSceneAsync(3); // Load scene asynchronously after the wait
    }
}
