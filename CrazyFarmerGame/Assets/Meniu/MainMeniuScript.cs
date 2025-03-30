using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMeniuScript : MonoBehaviour
{
    private LevelLoader levelLoader;

    void Start()
    {
        levelLoader = FindFirstObjectByType<LevelLoader>(); // Correct method
    }

    public void PlayButton()
    {
        if (levelLoader != null)
        {
            levelLoader.LoadScene(3); // Load Main Game (scene 3)
        }
        else
        {
            Debug.LogError("LevelLoader not found! Make sure it's in the scene.");
            SceneManager.LoadScene(3); // Fallback in case LevelLoader is missing
        }
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene(1); // Load Settings (scene 1)
    }
}
