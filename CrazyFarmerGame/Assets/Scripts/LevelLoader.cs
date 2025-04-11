using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;  // Reference to the Animator for the scene transition
    public float transitionTime = 1f; // Duration of the transition effect (in seconds)

    // This method should be called when the play button or any other UI button is pressed to load the next scene
    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneWithTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    // Coroutine to handle scene loading with transition effect
    IEnumerator LoadSceneWithTransition(int sceneIndex)
    {
        // Trigger the transition animation
        transition.SetTrigger("Start");

        // Wait for the transition to finish (time set in transitionTime)
        yield return new WaitForSeconds(transitionTime);

        // Load the next scene
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    // Optional: You can also create a method for loading specific scenes
    public void LoadSpecificScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneWithTransition(sceneIndex));
    }
}
