using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RestartSceneScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestTimeText;

    void Start()
    {
        // Load best time and final time
        float bestTime = PlayerPrefs.GetFloat("bestTime", 0f);
        float finalTime = PlayerPrefs.GetFloat("finalTime", 0f); // Ensure this is the final time, not best time

        // Convert best time to minutes and seconds
        int bestMinutes = Mathf.FloorToInt(bestTime / 60);
        int bestSeconds = Mathf.FloorToInt(bestTime % 60);
        bestTimeText.text = $"Best Time: {bestMinutes:00}:{bestSeconds:00}";


    }

    public void RestartScene()
    {
        Timer timer = FindFirstObjectByType<Timer>();
        timer?.OnPlayerDeath(); // Save final time before restart

        SceneManager.LoadSceneAsync(3);
    }

    public void BackToMenu()
    {
        Timer timer = FindFirstObjectByType<Timer>();
        timer?.OnPlayerDeath(); // Save final time before going back to the menu

        SceneManager.LoadSceneAsync(0);
    }

    public void GameOver()
    {
        Timer timer = FindFirstObjectByType<Timer>();
        if (timer != null)
        {
            timer.OnPlayerDeath();
        }
        else
        {
            Debug.LogError("Timer not found! Make sure it's active in the scene.");
        }
    }
}
