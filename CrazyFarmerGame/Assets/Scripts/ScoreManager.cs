using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject Enemy;
    public TextMeshProUGUI scoreText;
    private bool Added = false;
    int amount;


    int score = 0;

    public List<GameObject> Enemies;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        
        //score = score + 10;
;
        Debug.Log(score);
        scoreText.text = "Score: " + score.ToString();


        
    }

    public void AddScore(int amount)
    {
        score+= amount;
    }







}
