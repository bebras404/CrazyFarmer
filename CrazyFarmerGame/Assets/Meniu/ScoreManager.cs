using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject Enemy;
    public TextMeshProUGUI scoreText;
    private bool Added = false;


    int score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.IsDestroyed() && !Added)
        {
            score = score + 10;
            Added = true;
            Debug.Log(score);
            scoreText.text = "Score: " + score.ToString();

        }
    }
}
