using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneScript : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
