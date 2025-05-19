using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMeniuScript : MonoBehaviour
{
    public void PlayButton()
    {
        
        SceneManager.LoadSceneAsync(3);
    }

    public void SettingsButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void CreditsButton()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void BackButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void QuitGame()
    {

        PlayerPrefs.DeleteAll();
        //Application.Quit();
    }

    public void ShopButton()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void StatsButton()
    {
        SceneManager.LoadSceneAsync(6);
    }
}
