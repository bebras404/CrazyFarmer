using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneScript : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
