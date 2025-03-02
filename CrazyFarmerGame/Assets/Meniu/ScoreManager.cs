using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    GameObject Enemy;
    public TextMeshProUGUI scoreText;

    int score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: "+score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.activeInHierarchy)
        {
            score = score + 10;
        }
    }
}
