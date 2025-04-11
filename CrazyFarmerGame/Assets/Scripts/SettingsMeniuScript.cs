using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMeniuScript : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
