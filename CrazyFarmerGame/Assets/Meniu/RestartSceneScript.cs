using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestTimeText;
    //[SerializeField] private TextMeshProUGUI finalTimeText;

    void Start()
    {
        float bestTime = PlayerPrefs.GetFloat("bestTime", 0f);
        float finalTime = PlayerPrefs.GetFloat("finalTime", 0f);

        int bestMinutes = Mathf.FloorToInt(bestTime / 60);
        int bestSeconds = Mathf.FloorToInt(bestTime % 60);
        bestTimeText.text = $"Best Time: {bestMinutes:00}:{bestSeconds:00}";

        int finalMinutes = Mathf.FloorToInt(finalTime / 60);
        int finalSeconds = Mathf.FloorToInt(finalTime % 60);
        //finalTimeText.text = $"Final Time: {finalMinutes:00}:{finalSeconds:00}";

        Debug.Log($"Final Time Loaded: {finalTime}");
        Debug.Log($"Best Time Loaded: {bestTime}");
    }

    public void RestartScene()
    {
        SaveFinalTime();
        SceneManager.LoadSceneAsync(3);
    }

    public void BackToMenu()
    {
        SaveFinalTime();
        SceneManager.LoadSceneAsync(0);
    }

    public void GameOver()
    {
        SaveFinalTime();
    }

    private void SaveFinalTime()
    {
        if (Timer.Instance != null)
        {
            Timer.Instance.OnPlayerDeath();
        }
        else
        {
            //Debug.LogError("Timer not found! Make sure the Timer is active in the scene.");
        }
    }
}
