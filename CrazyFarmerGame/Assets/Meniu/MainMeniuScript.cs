using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMeniuScript : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void SettingsButton()
    {
        SceneManager.LoadSceneAsync(1);
    }


}
