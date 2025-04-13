using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public SaveManager savem;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int score = 0;
    private long highScore = 0;

    void Start()
    {
        highScore = savem.PassHighScore();
        // Update UI
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;

        // Check if high score is beaten
        if (score > highScore)
        {
            highScore = score;
            savem.SetScoreCount(highScore);
        }

        // Update UI
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore.ToString();
    }

}