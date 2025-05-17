using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RestartSceneScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestTimeText;

    void Start()
    {


    }

    public void RestartScene()
    {
       
        SceneManager.LoadSceneAsync(3);
    }

    public void BackToMenu()
    {

        SceneManager.LoadSceneAsync(0);
    }
    public void ShowCredits()
    {

        SceneManager.LoadSceneAsync(4);
    }


}
