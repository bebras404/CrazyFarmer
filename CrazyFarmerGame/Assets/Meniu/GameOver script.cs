using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public GameObject player;

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
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth.health == 8)
        {
            SceneManager.LoadSceneAsync(3);
            Console.WriteLine("VEIKIAAAAAAAAAA");
        }
        //if (player.gameObject.activeInHierarchy)
        //{

        //}


    }
}
