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
       
        SceneManager.LoadSceneAsync(3);
    }

    public void BackToMenu()
    {

        SceneManager.LoadSceneAsync(0);
    }

   
}
