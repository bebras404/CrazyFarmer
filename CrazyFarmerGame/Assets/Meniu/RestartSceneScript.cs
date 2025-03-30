using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneScript : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
