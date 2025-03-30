using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private float bestTime = 0f;

    void Start()
    {
        if (PlayerPrefs.HasKey("bestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("bestTime");
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = $"Time: {minutes:00}:{seconds:00}";

        // Save Best Time
        if (elapsedTime > bestTime)
        {
            bestTime = elapsedTime;
            PlayerPrefs.SetFloat("bestTime", bestTime);
            PlayerPrefs.Save();
        }
    }

    public void OnPlayerDeath()
    {
        Debug.Log($"Player Died. Saving Final Time: {elapsedTime} seconds.");
        PlayerPrefs.SetFloat("finalTime", elapsedTime); // Save final time correctly
        PlayerPrefs.Save();
    }

}
