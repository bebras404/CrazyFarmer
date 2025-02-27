using System;
using Unity.VisualScripting;
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
        if (LastKnownHealth <= 2 && player.gameObject == null)
        {
            SceneManager.LoadSceneAsync(3);
        }


    }
}
