using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public GameObject player;

    

    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth.health <=0)
        {

        }
    }

    public void GameOverScreen()
    {
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
